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
    public class AddFrontEndAccountController : ApiController
    {
        private ProjectBLL _projectBLL = new ProjectBLL();
        private FrontEndAccountBLL _frontBLL = new FrontEndAccountBLL();
        private FrontEndAccountProjectMappingBLL _frontMapBLL = new FrontEndAccountProjectMappingBLL();

        [ApiAuthorize]
        public BaseResultEntity Post(AddFrontEndAccountRequestModel req)
        {
            Logger.LogDebug("AddFrontEndAccount Request:" + JsonHelper.SerializeObject(req), "AddFrontEndAccountController", "Post");
            var ret = new BaseResultEntity()
            {
                Code = 0,
                ErrMsg = ""
            };

            try
            {
                foreach(int i in req.ProjectID)
                {
                    if (_projectBLL.GetModels(x => x.ID == i).FirstOrDefault() == null)
                    {
                        ret.Code = 201;
                        ret.ErrMsg = "项目ID不存在！";
                        return ret;
                    }
                }
                if(string.IsNullOrWhiteSpace(req.Account) || string.IsNullOrWhiteSpace(req.Password))
                {
                    ret.Code = 601;
                    ret.ErrMsg = "账号或密码不允许为空！";
                }
                else if(_frontBLL.GetModels(x => x.Account == req.Account).FirstOrDefault() != null)
                {
                    ret.Code = 602;
                    ret.ErrMsg = "账号已存在！";
                }
                else
                {
                    var _dbAccount = new FrontEndAccount()
                    {
                        //ProjectID = req.ProjectID,
                        Account = req.Account,
                        Password = req.Password.ToUpper(),
                        CreateTime = DateTime.Now,
                        LastUpdate = DateTime.Now
                    };
                    _frontBLL.Add(_dbAccount);

                    var _dbMapList = new List<FrontEndAccountProjectMapping>();
                    foreach(int i in req.ProjectID)
                    {
                        var _dbMap = new FrontEndAccountProjectMapping()
                        {
                            ProjectID = i,
                            FrontEndAccountID = _dbAccount.ID,
                            CreateTime = DateTime.Now,
                            LastUpdate = DateTime.Now
                        };
                        _dbMapList.Add(_dbMap);
                    }
                    _frontMapBLL.AddRange(_dbMapList);
                }
            }
            catch(Exception ex)
            {
                //var acc = _frontBLL.GetModels(x => x.Account == req.Account).FirstOrDefault();
                //if (acc != null)
                //{
                //    _frontBLL.Delete(acc);
                //}
                Logger.LogException("添加前台账号时发生异常！", "AddFrontEndAccountController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }
            return ret;
        }
    }
}
