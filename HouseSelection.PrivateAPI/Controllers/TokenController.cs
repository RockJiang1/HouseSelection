using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HouseSelection.BLL;
using HouseSelection.Model;
using HouseSelection.Utility;
using HouseSelection.Enum;
using HouseSelection.LoggerHelper;
using HouseSelection.Authorize;

namespace HouseSelection.PrivateAPI.Controllers
{
    public class TokenController : ApiController
    {
        private ApplicationBLL _appBLL = new ApplicationBLL();

        public string GetAppId()
        {
            return Guid.NewGuid().ToString().Replace("-", "").ToUpper().Substring(0, 16) + "|" + Guid.NewGuid().ToString().Replace("-", "").ToUpper().Substring(0, 30);
        }

        public TokenResultEntity Post(ApplicationEntity data)
        {
            var result = new TokenResultEntity();

            // 获取应用信息
            var app = _appBLL.GetModels(x => x.APPID == data.APPID && x.APPSECRET == data.APPSECRET).FirstOrDefault();

            if (app == null)
            {
                result.code = (int)InterfaceResultEnum.AppError;
                result.errMsg = EnumHelper.GetDescription(InterfaceResultEnum.AppError);

                Logger.LogInfo(string.Format("获取Token失败，AppId:{0},AppSecret:{1}", data.APPID, data.APPSECRET), "TokenController", "Post");
                return result;
            }

            var requestAccount = data.APPID;
            var requestUserId = app.ID;

            int expiry = 3600;

            var token = AuthorizeHelper.AddToken(requestUserId, requestAccount, expiry);

            if (token != null)
            {
                result.code = (int)InterfaceResultEnum.Success;
                result.Access_Token = token.AccessToken;
                result.Expiry = token.Expiry;
                Logger.LogInfo(string.Format("获取Token成功，AppId:{0},AppSecret:{1},AccessToken:{2}", data.APPID, data.APPSECRET, token.AccessToken), "TokenController", "Post");
            }
            else
            {
                result.code = (int)InterfaceResultEnum.AppError;
                result.errMsg = EnumHelper.GetDescription(InterfaceResultEnum.AppError);
                Logger.LogInfo(string.Format("获取Token失败，AppId:{0},AppSecret:{1}", data.APPSECRET, data.APPSECRET), "TokenController", "Post");
            }
            return result;

        }
    }
}
