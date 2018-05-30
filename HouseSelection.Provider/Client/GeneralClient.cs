using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.Provider.Client.Request;
using System.Configuration;
using System.Security.Cryptography;
using System.Web.Security;
using HouseSelection.NetworkHelper;
using Newtonsoft.Json;

namespace HouseSelection.Provider.Client
{
    public class GeneralClient :BaseClient 
    {
        protected override string CreateQueryString(BaseRequest req)
        {
            string test = JsonConvert.SerializeObject(req);

            return UnicodeHelper.ToJSUnicode(JsonConvert.SerializeObject(req, new JsonSerializerSettings()
            {
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
            }));
        }
        //protected override string CreateQueryString(BaseRequest req)
        //{
        //    string result = null;

        //    string queryString = "";

        //    //获取参数列表
        //    IDictionary<string, string> args = GetParams(req);

        //    var value = string.Join("", args.Select(x => x.Key + "" + x.Value.ToString()).ToArray());

        //    //从REQ返回
        //    if (args.Count > 0)
        //    {
        //        foreach (var arg in args)
        //        {
        //            //Logger.LogInfo("key:" + arg.Key + " Value:" + arg.Value, "DZDPClient", "CreateQueryString");
        //            queryString += (queryString.Length == 0 ? "" : "&") + arg.Key + "=" + arg.Value;
        //        }
        //    }

        //    var sign = FormsAuthentication.HashPasswordForStoringInConfigFile(SignKey + value, "SHA1").ToLower();
        //    result = queryString + "&sign=" + sign;

        //    return result;
        //}

        /// <summary>
        /// 数字签名
        /// </summary>
        private string SignKey
        {
            get
            {
                return ConfigurationManager.AppSettings["MTCSignKey"];
            }
        }
    }
}


