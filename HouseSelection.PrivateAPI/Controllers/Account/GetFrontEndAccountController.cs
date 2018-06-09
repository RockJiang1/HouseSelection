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
    public class GetFrontEndAccountController : ApiController
    {
        //private ProjectBLL _projectBLL = new ProjectBLL();
        private FrontEndAccountBLL _frontBLL = new FrontEndAccountBLL();
        private FrontEndAccountProjectMappingBLL _frontMapBLL = new FrontEndAccountProjectMappingBLL();

        [ApiAuthorize]
        public GetFrontEndAccountResultEntity Post(GetFrontEndAccountRequestModel req)
        {
            Logger.LogDebug("GetFrontEndAccount Request:" + JsonHelper.SerializeObject(req), "GetFrontEndAccountController", "Post");
            var ret = new GetFrontEndAccountResultEntity()
            {
                Code = 0,
                ErrMsg = ""
            };

            try
            {
                var _dbAccountList = new List<FrontEndAccount>();
                //if (req.ProjectID == 0)//获取全部
                //{
                if(string.IsNullOrWhiteSpace(req.SearchStr))
                {
                    _dbAccountList = _frontBLL.GetModelsByPage(req.PageSize, req.PageIndex, true, x => x.ID, x => 1 == 1).ToList();
                    ret.RecordCount = _frontBLL.GetModels(x => 1 == 1).Count();
                }
                else
                {
                    _dbAccountList = _frontBLL.GetModelsByPage(req.PageSize, req.PageIndex, true, x => x.ID, x => x.Account.Contains(req.SearchStr)).ToList();
                    ret.RecordCount = _frontBLL.GetModels(x => x.Account.Contains(req.SearchStr)).Count();
                }
                //}
                //else
                //{
                //    if (_projectBLL.GetModels(x => x.ID == req.ProjectID).FirstOrDefault() == null)
                //    {
                //        ret.Code = 201;
                //        ret.ErrMsg = "项目ID不存在！";
                //        return ret;
                //    }
                //    else
                //    {
                //        if (string.IsNullOrWhiteSpace(req.SearchStr))
                //        {
                //            _dbAccountList = _frontBLL.GetModelsByPage(req.PageSize, req.PageIndex, true, x => x.ID, x => x.ProjectID == req.ProjectID).ToList();
                //            ret.RecordCount = _frontBLL.GetModels(x => x.ProjectID == req.ProjectID).Count();
                //        }
                //        else
                //        {
                //            _dbAccountList = _frontBLL.GetModelsByPage(req.PageSize, req.PageIndex, true, x => x.ID, x => x.ProjectID == req.ProjectID && x.Account.Contains(req.SearchStr)).ToList();
                //            ret.RecordCount = _frontBLL.GetModels(x => x.ProjectID == req.ProjectID && x.Account.Contains(req.SearchStr)).Count();
                //        }
                //    }
                //}
                var _accountList = new List<FrontEndAccountEntity>();
                foreach (var dbAcc in _dbAccountList)
                {
                    var _acc = new FrontEndAccountEntity()
                    {
                        AccountID = dbAcc.ID,
                        //ProjectNumber = dbAcc.Project.Number,
                        //ProjectName = dbAcc.Project.Name,
                        Account = dbAcc.Account
                    };
                    var _dbAccProList = _frontMapBLL.GetModels(x => x.FrontEndAccountID == dbAcc.ID).ToList();
                    var _accProList = new List<AccountProjectEntity>();
                    foreach (var map in _dbAccProList)
                    {
                        var _accPro = new AccountProjectEntity()
                        {
                            ProjectID = map.ProjectID,
                            ProjectNumber = map.Project.Number,
                            ProjectName = map.Project.Name
                        };
                        _accProList.Add(_accPro);
                    }
                    _acc.ProjectList = _accProList;
                    _accountList.Add(_acc);
                }
                ret.AccountList = _accountList;
            }
            catch (Exception ex)
            {
                Logger.LogException("搜索账号列表时发生异常！", "GetFrontEndAccountController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }
            return ret;
        }
    }
}
