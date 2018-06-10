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
    public class EditFrontEndAccountController : ApiController
    {
        private ProjectBLL _projectBLL = new ProjectBLL();
        private FrontEndAccountBLL _frontBLL = new FrontEndAccountBLL();
        private FrontEndAccountProjectMappingBLL _frontMapBLL = new FrontEndAccountProjectMappingBLL();

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
                foreach (int i in req.ProjectID)
                {
                    if (_projectBLL.GetModels(x => x.ID == i).FirstOrDefault() == null)
                    {
                        ret.Code = 201;
                        ret.ErrMsg = "项目ID不存在！";
                        return ret;
                    }
                }

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

                //先删
                var _dbMapList = _frontMapBLL.GetModels(x => x.FrontEndAccountID == req.AccountID).ToList();
                _frontMapBLL.DeleteRange(_dbMapList); 
                //后插
                var _dbNewMapList = new List<FrontEndAccountProjectMapping>();
                foreach (int i in req.ProjectID)
                {
                    var _dbMap = new FrontEndAccountProjectMapping()
                    {
                        ProjectID = i,
                        FrontEndAccountID = _dbAccount.ID,
                        CreateTime = DateTime.Now,
                        LastUpdate = DateTime.Now
                    };
                    _dbNewMapList.Add(_dbMap);
                }
                _frontMapBLL.AddRange(_dbNewMapList);

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
