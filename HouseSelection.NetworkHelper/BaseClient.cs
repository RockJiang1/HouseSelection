using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web;
using Newtonsoft.Json;
using HouseSelection.LoggerHelper;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;


namespace HouseSelection.NetworkHelper
{
    public abstract class BaseClient
    {
        /// <summary>
        /// 执行API请求
        /// </summary>
        /// <typeparam name="T">API返回的信息类型</typeparam>
        /// <param name="request">请求信息</param>
        /// <returns>返回信息实体</returns>
        public T InvokeAPI<T>(BaseRequest request)
        {
            //从远程API请求数据
            int status = 0;
            string json = RequestUrl(request, out status);

            if (status != 200)
            {
                return default(T);
            }

            //如果状态返回正常那么将返回的消息转换为对象
            Logger.LogInfo("得到" + request.GetType().Name + "的返回结果：" + json + "正在转换对象", "BaseClient", "InvokeAPI");
            //转换订单信息
            T result = JsonConvert.DeserializeObject<T>(json);

            return result;
        }

        /// <summary>
        /// URL请求
        /// </summary>
        /// <param name="req">请求</param>
        /// <returns>请求结果</returns>
        private string RequestUrl(BaseRequest req, out int status)
        {
            string result = null;
            status = 0;
            string url = req.Url;
            HttpWebResponse response = null;
            try
            {
                switch (req.FormMethod)
                {
                    case FormMethods.Get:
                        response = this.DoGet(req);
                        break;

                    case FormMethods.Post:
                        response = this.DoPost(req);
                        break;

                    case FormMethods.Put:
                        response = this.DoPut(req);
                        break;

                    default:
                        response = this.DoGet(req);
                        break;
                }
                Encoding responseEncoding = !string.IsNullOrEmpty(response.CharacterSet) ? Encoding.GetEncoding(response.CharacterSet) : Encoding.UTF8;
                Logger.LogInfo("成功获取返回编码，值：" + responseEncoding + " 开始读取回复内容", "BaseClient", "RequestUrl");
                using (StreamReader sr = new StreamReader(response.GetResponseStream(), responseEncoding))
                {
                    result = sr.ReadToEnd();
                }
                status = (int)response.StatusCode;
                Logger.LogInfo("请求执行成功，状态值：" + status + ",返回值：" + result, "BaseClient", "RequestUrl");
            }
            catch (WebException wexc1)
            {
                // any statusCode other than 200 gets caught here
                if (wexc1.Status == WebExceptionStatus.ProtocolError)
                {
                    // can also get the decription:
                    //  ((HttpWebResponse)wexc1.Response).StatusDescription;
                    status = (int)((HttpWebResponse)wexc1.Response).StatusCode;
                }
                Logger.LogException("请求执行中发生异常，状态值：" + status, "BaseClient", "RequestUrl", wexc1);
            }
            catch (Exception ex)
            {
                Logger.LogException("请求执行中发生异常," + ex.Message, "BaseClient", "RequestUrl", ex);
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
                Logger.LogInfo("成功销毁response对象", "BaseClient", "RequestUrl");
            }
            return result;
        }

        /// <summary>
        /// 执行GET请求
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public HttpWebResponse DoGet(BaseRequest req)
        {
            Logger.LogInfo("当前请求为Get，正在生成queryString并拼接到Url", "BaseClient", "DoGet");
            //创建参数字符串
            var queryString = this.CreateQueryString(req);
            Logger.LogInfo("生成queryString完成：" + queryString, "BaseClient", "DoGet");

            //创建完整URL
            var url = req.Url + (req.Url.IndexOf("?") >= 0 ? "" : "?") + queryString;

            Logger.LogInfo("开始执行请求，请求地址：" + url, "BaseClient", "DoGet");
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

            request.Method = "GET";
            request.ContentType = "application/json";

            //开始GET数据
            return (HttpWebResponse)request.GetResponse();
        }

        public HttpWebResponse DoPut(BaseRequest req)
        {
            Logger.LogInfo("当前请求为Put，正在生成queryString", "BaseClient", "DoPut");
            //创建参数字符串
            var queryString = this.CreateQueryString(req);
            Logger.LogInfo("生成queryString完成：" + queryString, "BaseClient", "DoPut");
            //二进制序列化
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] data = encoding.GetBytes(queryString);

            //创建完整URL
            var url = req.Url;

            Logger.LogInfo("开始执行请求，请求地址：" + url, "BaseClient", "DoPut");
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

            request.Method = "Put";
            if (req.ContentType == PostRequestContentType.Form)
            {
                request.ContentType = "application/x-www-form-urlencoded";
            }
            else
            {
                request.ContentType = "application/json;charset=utf-8";
            }
            request.ContentLength = data.Length;
            var stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();

            //开始POST数据
            return (HttpWebResponse)request.GetResponse();
        }

        /// <summary>
        /// 执行POST请求
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public HttpWebResponse DoPost(BaseRequest req)
        {
            Logger.LogInfo("当前请求为Post，正在生成queryString", "BaseClient", "DoPost");
            //创建参数字符串
            var queryString = this.CreateQueryString(req);
            Logger.LogInfo("生成queryString完成：" + queryString, "BaseClient", "DoPost");
            //二进制序列化
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] data = encoding.GetBytes(queryString);

            //创建完整URL
            var url = req.Url;

            Logger.LogInfo("开始执行请求，请求地址：" + url, "BaseClient", "DoPost");
            HttpWebRequest request = null;
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = (HttpWebRequest)WebRequest.Create(url) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                request = (HttpWebRequest)WebRequest.Create(url) as HttpWebRequest;
            }

            Logger.LogInfo("开始执行请求，请求地址：" + url, "BaseClient", "DoPost");
            //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

            request.Method = "POST";
            if (req.ContentType == PostRequestContentType.Form)
            {
                request.ContentType = "application/x-www-form-urlencoded";
            }
            else
            {
                request.ContentType = "application/json;charset=utf-8";
            }
            if (GlobalTokenHelper.gToken != "")
            {
                request.Headers.Add("access_token", GlobalTokenHelper.gToken);
            }


            request.ContentLength = data.Length;
            var stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();

            //开始POST数据
            return (HttpWebResponse)request.GetResponse();
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }

        /// <summary>
        /// URL请求参数UTF8编码
        /// </summary>
        /// <param name="value">源字符串</param>
        /// <returns>编码后的字符串</returns>
        protected string Utf8_Url_Encode(string value)
        {
            return HttpUtility.UrlEncode(value, System.Text.Encoding.UTF8);
        }

        /// <summary>
        /// 计算Hex值
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        protected string Hex(string str)
        {
            byte[] value = Encoding.UTF8.GetBytes(str);
            string delimitedHexHash = BitConverter.ToString(value);
            string hexHash = delimitedHexHash.Replace("-", "").ToLower();
            return hexHash;
        }

        /// <summary>
        /// 获取参数列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        protected IDictionary<string, string> GetParams(BaseRequest req)
        {
            //获取请求对象中所有标记了作为参数的属性
            var properties = req.GetType().GetProperties().Where(x => x.GetCustomAttributes(typeof(RequestPropertyAttribute), true).Length > 0).ToArray();

            IDictionary<string, string> args = new Dictionary<string, string>();

            foreach (var p in properties)
            {
                //获取属性配置
                RequestPropertyAttribute pa = (RequestPropertyAttribute)p.GetCustomAttributes(typeof(RequestPropertyAttribute), true)[0];

                //获取Key
                var key = string.IsNullOrEmpty(pa.PropertyName) ? p.Name : pa.PropertyName;

                //不序列化NULL属性
                var jSetting = new JsonSerializerSettings();
                jSetting.NullValueHandling = NullValueHandling.Ignore;

                if (p.GetValue(req, null) == null && pa.ExcludeIfNull)
                {
                    //值为空且为空时设置为排除，那么不处理
                    continue;
                }

                //获取值，如果值需要序列化为JSON那么序列化，否则直接取其String
                var value = pa.JsonSerializable ? JsonConvert.SerializeObject(p.GetValue(req, null), jSetting) : p.GetValue(req, null);

                args.Add(key, value == null ? "" : value.ToString());
            }

            return args.OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
        }

        /// <summary>
        /// 根据参数创建
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        protected abstract string CreateQueryString(BaseRequest req);
    }
}
