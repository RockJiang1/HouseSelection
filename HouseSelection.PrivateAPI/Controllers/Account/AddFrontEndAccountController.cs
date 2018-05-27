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

namespace HouseSelection.PrivateAPI.Controllers
{
    public class AddFrontEndAccountController : ApiController
    {
        private ProjectBLL _projectBLL = new ProjectBLL();
        private FrontEndAccountBLL _frontBLL = new FrontEndAccountBLL();

        [ApiAuthorize]
        public BaseResultEntity Post(AddFrontEndAccountRequestModel req)
        {
            var ret = new BaseResultEntity()
            {
                code = 0,
                errMsg = ""
            };

            try
            {
                if (_projectBLL.GetModels(x => x.ID == req.ProjectID).FirstOrDefault() == null)
                {
                    ret.code = 201;
                    ret.errMsg = "项目ID不存在！";
                }
                else if(string.IsNullOrWhiteSpace(req.Account) || string.IsNullOrWhiteSpace(req.Password))
                {
                    ret.code = 601;
                    ret.errMsg = "账号或密码不允许为空！";
                }
                else if(_frontBLL.GetModels(x => x.Account == req.Account).FirstOrDefault() != null)
                {
                    ret.code = 602;
                    ret.errMsg = "账号已存在！";
                }
                else
                {
                    var _dbAccount = new FrontEndAccount()
                    {
                        ProjectID = req.ProjectID,
                        Account = req.Account,
                        Password = req.Password.ToUpper(),
                        CreateTime = DateTime.Now,
                        LastUpdate = DateTime.Now
                    };
                    _frontBLL.Add(_dbAccount);
                }
            }
            catch(Exception ex)
            {
                Logger.LogException("添加前台账号时发生异常！", "AddFrontEndAccountController", "Post", ex);
                ret.code = 999;
                ret.errMsg = ex.Message;
            }
            return ret;
        }
    }
}
