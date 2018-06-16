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
using HouseSelection.FrontEndAPI.Models;

namespace HouseSelection.FrontEndAPI.Controllers
{
    public class RefreshTokenController : ApiController
    {
        public TokenResultEntity Post(RefreshTokenEntity data)
        {
            var result = new TokenResultEntity();

            // 获取应用信息
            var Token = AuthorizeHelper.GetTokenByRefreshToken(data.RefreshToken);

            if (Token == null)
            {
                result.Code = (int)InterfaceResultEnum.AppError;
                result.ErrMsg = EnumHelper.GetDescription(InterfaceResultEnum.AppError);

                Logger.LogInfo(string.Format("刷新Token失败，RefreshToken:{0}", data.RefreshToken), "RefreshTokenController", "Post");
                return result;
            }

            var requestAccount = Token.RequestAccount;
            var requestUserId = (int)Token.RequestUserId;

            int expiry = 3600;

            var token = AuthorizeHelper.AddToken(requestUserId, requestAccount, expiry);
            AuthorizeHelper.RemoveToken(data.RefreshToken);

            if (token != null)
            {
                result.Code = (int)InterfaceResultEnum.Success;
                result.Access_Token = token.AccessToken;
                result.Refresh_Token = token.RefreshToken;
                result.Expiry = token.Expiry;
                Logger.LogInfo(string.Format("刷新Token成功，RefreshToken:{0},AccessToken:{1}", data.RefreshToken, token.AccessToken), "RefreshTokenController", "Post");
            }
            else
            {
                result.Code = (int)InterfaceResultEnum.AppError;
                result.ErrMsg = EnumHelper.GetDescription(InterfaceResultEnum.AppError);
                Logger.LogInfo(string.Format("刷新Token失败，RefreshToken:{0}", data.RefreshToken), "RefreshTokenController", "Post");
            }
            return result;

        }
    }
}
