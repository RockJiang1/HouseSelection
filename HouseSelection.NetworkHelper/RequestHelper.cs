using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Collections.Specialized;
using System.Reflection;
using Newtonsoft.Json;
using HouseSelection.LoggerHelper;

namespace HouseSelection.NetworkHelper
{
    public class RequestHelper
    {
        /// <summary>
        /// 将键值对中的值映射到制定类型的请求对象中
        /// </summary>
        /// <typeparam name="T">请求对象的类型</typeparam>
        /// <param name="source">键值对数据源</param>
        /// <returns>请求对象</returns>
        /// <exception cref="ParseRequestException">字段转换异常</exception>
        public static T ParseRequest<T>(NameValueCollection source)
        {
            Logger.LogInfo("正在转换请求，类型为：" + typeof(T).Name, "RequestHelper", "ParseRequest");

            //获取请求对象中所有标记了作为参数的属性
            var properties = typeof(T).GetProperties().Where(x => x.GetCustomAttributes(typeof(RequestPropertyAttribute), true).Length > 0).ToArray();

            Logger.LogInfo("正在创建类型的空实例", "RequestHelper", "ParseRequest");
            //创建实例
            T result = (T)Activator.CreateInstance(typeof(T));

            foreach (var p in properties)
            {
                //获取属性配置
                RequestPropertyAttribute pa = (RequestPropertyAttribute)p.GetCustomAttributes(typeof(RequestPropertyAttribute), true)[0];

                //获取Key
                var key = string.IsNullOrEmpty(pa.PropertyName) ? p.Name : pa.PropertyName;

                Logger.LogInfo("正在处理属性 " + key + " 值为 " + HttpUtility.UrlDecode(source[key]), "RequestHelper", "ParseRequest");

                if (pa.NoSet)
                {
                    Logger.LogInfo("属性 " + key + " 被设置为NOSET，跳过值设置", "RequestHelper", "ParseRequest");
                    continue;
                }

                if (!pa.ExcludeIfNull && (!source.AllKeys.Contains(key) || source[key] == null))
                {
                    //如果当前属性不允许跳过，并且当前属性不存在于请求中，那么抛出异常
                    throw new ParseRequestException(key);
                }
                else if (pa.ExcludeIfNull && HttpUtility.UrlDecode(source[key]) == null)
                {
                    //如果当前字段可以被跳过，且值是空，那么就跳过
                    continue;
                }

                //获取原始值
                string sourceValue = HttpUtility.UrlDecode(source[key]);

                //定义最终值
                object value = null;

                if (!pa.JsonSerializable)
                {
                    //如果该属性不需要Json处理
                    MethodInfo parseMethod = null;

                    try
                    {
                        //获取转换需要的方法
                        parseMethod = p.PropertyType.GetMethods(BindingFlags.Static | BindingFlags.Public)
                            .Where(
                                x =>
                                    x.Name == "Parse" &&
                                    x.GetParameters().Length == 1 &&
                                    x.GetParameters()[0].ParameterType == typeof(string)
                                    )
                            .FirstOrDefault();

                        if (parseMethod == null)
                        {
                            //如果未能在类型中找到Parse方法，那么尝试在泛型中查找该方法
                            var gaProperty = p.PropertyType.GetGenericArguments();

                            if (gaProperty.Length > 0)
                            {
                                parseMethod = gaProperty[0].GetMethods(BindingFlags.Static | BindingFlags.Public)
                                    .Where(
                                        x =>
                                            x.Name == "Parse" &&
                                            x.GetParameters().Length == 1 &&
                                            x.GetParameters()[0].ParameterType == typeof(string)
                                            )
                                    .FirstOrDefault();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.LogException("获取基础类型的转换方法时出现异常，类型名称：" + p.PropertyType.Name + "，出错Key：" + key + " 值:" + sourceValue, "RequestHelper", "ParseRequest", ex);
                        throw new ParseRequestException(key);
                    }

                    try
                    {
                        //如果方法不存在则使用String作为最后的值
                        if (parseMethod == null)
                        {
                            value = sourceValue.ToString();
                        }
                        else
                        {
                            value = parseMethod.Invoke(null, new object[] { sourceValue.ToString() });
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.LogException("基础数据类型转换请求时出现异常，出错Key：" + key + " 值:" + sourceValue, "RequestHelper", "ParseRequest", ex);
                        throw new ParseRequestException(key);
                    }
                }
                else
                {
                    try
                    {
                        value = JsonConvert.DeserializeObject(sourceValue, p.PropertyType);
                    }
                    catch (Exception ex)
                    {
                        Logger.LogException("Json转换请求时出现异常，出错Key：" + key + " 值:" + sourceValue, "RequestHelper", "ParseRequest", ex);
                        throw new ParseRequestException(key);
                    }
                }

                try
                {
                    //设置值到返回对象
                    p.SetValue(result, value, null);
                }
                catch (Exception ex)
                {
                    Logger.LogException("为对象动态设置值时出现异常，出错Key：" + key + " 值:" + sourceValue, "RequestHelper", "ParseRequest", ex);
                    throw new ParseRequestException(key);
                }
            }

            return result;
        }
    }
}
