using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HouseSelection.LoggerHelper;

namespace HouseSelection.NetworkHelper
{
    public abstract class BaseRequest
    {
        /// <summary>
        /// 获取一个值，表示API的地址信息
        /// </summary>
        [JsonIgnore]
        protected abstract string APIAddress { get; }

        /// <summary>
        /// 获取一个值，表示API的基本地址信息
        /// </summary>
        [JsonIgnore]
        protected abstract string BaseUrl { get; }

        /// <summary>
        /// 请求的地址
        /// </summary>
        [JsonIgnore]
        public virtual string Url
        {
            get
            {
                string result = this.BaseUrl;

                if (string.IsNullOrEmpty(result))
                {
                    Logger.LogWarning("没有正确的获取基本地址信息", "BaseRequest", "Url");
                }
                else if (result.LastIndexOf("/") == result.Length - 1)
                {
                    result = result.Substring(0, result.Length - 1);
                }

                return result + this.APIAddress;
            }
        }

        /// <summary>
        /// 表单提交方式
        /// </summary>
        [JsonIgnore]
        public abstract FormMethods FormMethod
        {
            get;
        }

        /// <summary>
        /// 上下文类型
        /// </summary>
        [JsonIgnore]
        public abstract PostRequestContentType ContentType { get; }
    }
}
