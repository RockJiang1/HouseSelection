using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.NetworkHelper;
using System.Configuration;
using HouseSelection.Utility;

namespace HouseSelection.Provider.Client.Request
{
    public abstract class GeneralRequest : BaseRequest
    {
        public GeneralRequest()
        {
            this.timestamp = DateTimeHelper.GetUnixTimeStamp(DateTime.Now).ToString();
        }

        protected override string APIAddress
        {
            get { return ""; }
        }

        public override FormMethods FormMethod
        {
            get { return FormMethods.Post; }
        }

        protected override string BaseUrl
        {
            get { return ConfigurationManager.AppSettings["ApiBaseURL"]; }
        }

        public override PostRequestContentType ContentType
        {
            get { return PostRequestContentType.Json; }
        }

        public string NoParamUrl
        {
            get
            {
                string result = this.BaseUrl;

                if (string.IsNullOrEmpty(result))
                {
                    //Logger.LogWarning("没有正确的获取基本地址信息", "MTCReqeust", "NoParamUrl");
                }
                else if (result.LastIndexOf("/") == result.Length - 1)
                {
                    result = result.Substring(0, result.Length - 1);
                }

                return result + this.APIAddress;
            }
        }

        /// <summary>
        /// 认领门店返回的token【一店一token】 【系统级参数】 【必须】
        /// </summary>
        [RequestProperty]
        public string appAuthToken { get; set; }

        /// <summary>
        /// 交互数据的编码【建议UTF-8】【系统级参数】 【必须】
        /// </summary>
        [RequestProperty]
        public string charset
        {
            get
            {
                return "UTF-8";
            }
        }

        /// <summary>
        /// 当前请求的时间戳【单位是秒】【系统级参数】 【必须】
        /// </summary>
        [RequestProperty]
        public string timestamp { get; set; }

        /// <summary>
        /// 接口版本【默认是1】【系统级参数】 【必须】
        /// </summary>
        public string version
        {
            get
            {
                return "1";
            }
        }

        /// <summary>
        /// 请求的数字签名 【系统级参数】 【必须】
        /// </summary>
        public string sign { get; set; }
    }
}



