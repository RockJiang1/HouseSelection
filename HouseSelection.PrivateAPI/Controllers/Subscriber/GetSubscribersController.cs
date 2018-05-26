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
    public class GetSubscribersController : ApiController
    {
        ProjectBLL _projectBLL = new ProjectBLL();
        SubscriberProjectMappingBLL _subscriberBLL = new SubscriberProjectMappingBLL();

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
                if(_projectBLL.GetModels(x => x.ID == req.ProjectID).FirstOrDefault() == null)
                {
                    ret.code = 201;
                    ret.errMsg = "项目ID不存在！";
                }
                else
                {
                    var _dbSubList = _subscriberBLL.GetModelsByPage(req.PageSize, req.PageIndex, true, x => x.ID, x => x.ProjectID == req.ProjectID).ToList();
                    var _subList = new List<SubscriberEntity>();
                    foreach(var _dbSub in _dbSubList)
                    {
                        var _sub = new SubscriberEntity()
                        {
                            Name = _dbSub.Subscriber.Name,
                            IdentityNumber = _dbSub.Subscriber.IdentityNumber,
                            Telephone = _dbSub.Subscriber.Telephone,
                            Address = _dbSub.Subscriber.Address,
                            ZipCode = _dbSub.Subscriber.ZipCode,
                            MaritalStatus = _dbSub.Subscriber.MaritalStatus,
                            ResidenceArea = _dbSub.Subscriber.ResidenceArea,
                            WorkArea = _dbSub.Subscriber.WorkArea
                        };
                        _subList.Add(_sub);
                    }
                    ret.SubscriberList = _subList;
                    ret.recordCount = _subscriberBLL.GetModels(x => x.ProjectID == req.ProjectID).Count();
                }
                
            }
            catch(Exception ex)
            {
                Logger.LogException("获取认购人时发生异常", "GetSubscribersController", "Post", ex);
            }
            return ret;
        }
    }
}
