using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HouseSelection.PrivateAPI.Models;
using HouseSelection.BLL;
using HouseSelection.Model;
using HouseSelection.LoggerHelper;
using HouseSelection.Authorize;

namespace HouseSelection.PrivateAPI.Controllers
{
    public class GetAllSubscribersController : ApiController
    {
        //ProjectBLL _projectBLL = new ProjectBLL();
        HouseSelectionRecordBLL _selectionBLL = new HouseSelectionRecordBLL();
        //SubscriberProjectMappingBLL _subscriberBLL = new SubscriberProjectMappingBLL();
        SubscriberBLL _subscriberBLL = new SubscriberBLL();

        [ApiAuthorize]
        public GetSubscriberResultEntity Post(GetSubscriberRequestModel req)
        {
            var ret = new GetSubscriberResultEntity()
            {
                code = 0,
                errMsg = ""
            };
            try
            {
                //if(_projectBLL.GetModels(x => x.ID == req.ProjectID).FirstOrDefault() == null)
                //{
                //    ret.code = 201;
                //    ret.errMsg = "项目ID不存在！";
                //}
                //else
                //{
                //var _dbSubList = _subscriberBLL.GetModelsByPage(req.PageSize, req.PageIndex, true, x => x.ID, x => x.ProjectID == req.ProjectID).ToList();
                var _dbSubList = _subscriberBLL.GetModelsByPage(req.PageSize, req.PageIndex, true, x => x.ID, x => 1 == 1).ToList();
                var _subList = new List<SubscriberEntity>();
                    foreach(var _dbSub in _dbSubList)
                    {
                        var _sub = new SubscriberEntity()
                        {
                            ID = _dbSub.ID,
                            Name = _dbSub.Name,
                            IdentityNumber = _dbSub.IdentityNumber,
                            Telephone = _dbSub.Telephone,
                            Address = _dbSub.Address,
                            ZipCode = _dbSub.ZipCode,
                            MaritalStatus = _dbSub.MaritalStatus,
                            ResidenceArea = _dbSub.ResidenceArea,
                            WorkArea = _dbSub.WorkArea,
                        };
                        _subList.Add(_sub);
                    }
                    ret.SubscriberList = _subList;
                    ret.recordCount = _subscriberBLL.GetModels(x => 1 == 1).Count();
                //}
                
            }
            catch(Exception ex)
            {
                Logger.LogException("获取认购人时发生异常", "GetSubscribersController", "Post", ex);
            }
            return ret;
        }
    }
}
