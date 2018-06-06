using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HouseSelection.Model;
using HouseSelection.BLL;
using HouseSelection.Authorize;
using HouseSelection.LoggerHelper;
using HouseSelection.PrivateAPI.Models;
using HouseSelection.Utility;

namespace HouseSelection.PrivateAPI.Controllers
{
    public class EditFrontEndAccountPasswordController : ApiController
    {
        private ProjectBLL _projectBLL = new ProjectBLL();
        private FrontEndAccountBLL _frontBLL = new FrontEndAccountBLL();

        [ApiAuthorize]
        public BaseResultEntity Post(EditFrontEndAccountRequestModel req)
        {
            Logger.LogDebug("EditFrontEndAccountPassword Request:" + JsonHelper.SerializeObject(req), "EditFrontEndAccountPasswordController", "Post");
            var ret = new BaseResultEntity()
            {
                Code = 0,
                ErrMsg = ""
            };

            try
            {
                var _dbAccount = _frontBLL.GetModels(x => x.ID == req.AccountID).FirstOrDefault();
                if (string.IsNullOrWhiteSpace(req.Account) || string.IsNullOrWhiteSpace(req.Password) || string.IsNullOrWhiteSpace(req.BeforePassword))
                {
                    ret.Code = 601;
                    ret.ErrMsg = "账号或密码不允许为空！";
                }
                else if (_dbAccount == null)
                {
                    ret.Code = 603;
                    ret.ErrMsg = "账号ID不存在！";
                }
                else if (_dbAccount.Account != req.Account)
                {
                    ret.Code = 604;
                    ret.ErrMsg = "账号名称不匹配！";
                }
                else if (_dbAccount.Password.ToUpper() != req.BeforePassword.ToUpper())
                {
                    ret.Code = 605;
                    ret.ErrMsg = "原密码错误！";
                }
                else
                {
                    _dbAccount.Password = req.Password.ToUpper();
                    _frontBLL.Update(_dbAccount);
                }
            }
            catch (Exception ex)
            {
                Logger.LogException("修改前台账号时发生异常！", "EditFrontEndAccountPasswordController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }
            return ret;
        }
    }
}
