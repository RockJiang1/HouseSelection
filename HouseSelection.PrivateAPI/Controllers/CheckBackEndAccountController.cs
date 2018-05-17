using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using HouseSelection.PrivateAPI.Models;
using HouseSelection.BLL;
using HouseSelection.Model;
using HouseSelection.LoggerHelper;
using HouseSelection.Authorize;

namespace HouseSelection.PrivateAPI.Controllers
{
    public class CheckBackEndAccountController : ApiController
    {
        BackEndAccountBLL _bkAccountBLL = new BackEndAccountBLL();
        BackEndAccountLoginRecordBLL _bkLoginBLL = new BackEndAccountLoginRecordBLL();

        [ApiAuthorize]
        public BaseResultEntity Post(AccountModel Account)
        {
            var ret = new BaseResultEntity();
            try
            {
                if (Account != null && !string.IsNullOrWhiteSpace(Account.Account) && !string.IsNullOrWhiteSpace(Account.Password))
                {
                    var _account = _bkAccountBLL.GetModels(x => x.Account == Account.Account && x.Password.ToUpper() == Account.Password.ToUpper()).ToList();
                    if (_account != null && _account.Count() > 0)
                    {
                        _bkLoginBLL.Add(new BackEndAccountLoginRecord() { BackEndAccountID = _account.FirstOrDefault().ID, LoginTime = DateTime.Now, LoginIP = ((HttpContextWrapper)Request.Properties["MS_HttpContext"]).Request.UserHostAddress });
                        ret.code = 0;
                        ret.errMsg = "";
                    }
                    else
                    {
                        ret.code = 101;
                        ret.errMsg = "登陆账号/密码错误！";
                    }
                }
                else
                {
                    ret.code = 102;
                    ret.errMsg = "登陆账号/密码不允许为空！";
                }
                
            }
            catch(Exception ex)
            {
                Logger.LogException("验证后台登陆账号时发生异常！", "CheckBackEndAccountController", "Post", ex);
                ret.code = 999;
                ret.errMsg = ex.Message;
            }
            return ret;
        }
    }
}
