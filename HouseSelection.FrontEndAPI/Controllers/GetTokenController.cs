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

namespace HouseSelection.FrontEndAPI.Controllers
{
    public class GetTokenController : ApiController
    {
        private FrontEndAccountBLL _accountBLL = new FrontEndAccountBLL();

        public TokenResultEntity Post(AccountEntity data)
        {
            var result = new TokenResultEntity();

            // 获取应用信息
            var account = _accountBLL.GetModels(x => x.Account == data.Account && x.Password == data.Password).FirstOrDefault();

            if (account == null)
            {
                result.Code = (int)InterfaceResultEnum.AppError;
                result.ErrMsg = EnumHelper.GetDescription(InterfaceResultEnum.AppError);

                Logger.LogInfo(string.Format("获取Token失败，AppId:{0},AppSecret:{1}", data.Account, data.Password), "TokenController", "Post");
                return result;
            }

            var requestAccount = account.Account;
            var requestUserId = account.ID;

            int expiry = 3600;

            var token = AuthorizeHelper.AddToken(requestUserId, requestAccount, expiry);

            if (token != null)
            {
                result.Code = (int)InterfaceResultEnum.Success;
                result.Access_Token = token.AccessToken;
                result.Refresh_Token = token.RefreshToken;
                result.Expiry = token.Expiry;
                Logger.LogInfo(string.Format("获取Token成功，AppId:{0},AppSecret:{1},AccessToken:{2}", data.Account, data.Password, token.AccessToken), "TokenController", "Post");
            }
            else
            {
                result.Code = (int)InterfaceResultEnum.AppError;
                result.ErrMsg = EnumHelper.GetDescription(InterfaceResultEnum.AppError);
                Logger.LogInfo(string.Format("获取Token失败，AppId:{0},AppSecret:{1}", data.Account, data.Password), "TokenController", "Post");
            }
            return result;

        }
    }
}
