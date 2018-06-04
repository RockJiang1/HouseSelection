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
using HouseSelection.Utility;

namespace HouseSelection.PrivateAPI.Controllers
{
    public class GetShakingNumbersController : ApiController
    {
        private ProjectGroupBLL _projectGroupBLL = new ProjectGroupBLL();
        private ShakingNumberResultBLL _shakingNumberBLL = new ShakingNumberResultBLL();

        [ApiAuthorize]
        public GetShakingNumbersResultEntity Post(GetShakingNumbersRequestModel req)
        {
            var ret = new GetShakingNumbersResultEntity()
            {
                code = 0,
                errMsg = ""
            };

            try
            {
                if(_projectGroupBLL.GetModels(x => x.ID == req.ProjectGroupID).FirstOrDefault() == null)
                {
                    ret.code = 202;
                    ret.errMsg = "项目分组ID不存在！";
                }
                else
                {
                    var _dbShakingList = _shakingNumberBLL.GetModelsByPage(req.PageSize, req.PageIndex, true, x => x.ShakingNumberSequance, x => x.ProjectGroupID == req.ProjectGroupID).ToList();
                    List<GetShakingNumberResultEntity> _shakingList = new List<GetShakingNumberResultEntity>();
                    foreach(var dbShaking in _dbShakingList)
                    {
                        GetShakingNumberResultEntity _shaking = new GetShakingNumberResultEntity()
                        {
                            ShakingNumberSequance = dbShaking.ShakingNumberSequance,
                            SelectHouseSequance = dbShaking.SelectHouseSequance,
                            ShakingNumber = dbShaking.ShakingNumber,
                            Subscriber = new SubscriberEntity()
                            {
                                ID = dbShaking.SubscriberProjectMapping.Subscriber.ID,
                                Name = dbShaking.SubscriberProjectMapping.Subscriber.Name,
                                IdentityNumber = dbShaking.SubscriberProjectMapping.Subscriber.IdentityNumber,
                                Telephone = dbShaking.SubscriberProjectMapping.Subscriber.Telephone,
                                Address = dbShaking.SubscriberProjectMapping.Subscriber.Address,
                                ZipCode = dbShaking.SubscriberProjectMapping.Subscriber.ZipCode,
                                MaritalStatus = dbShaking.SubscriberProjectMapping.Subscriber.MaritalStatus,
                                ResidenceArea = dbShaking.SubscriberProjectMapping.Subscriber.ResidenceArea,
                                WorkArea = dbShaking.SubscriberProjectMapping.Subscriber.WorkArea
                            },
                        };
                        _shakingList.Add(_shaking);
                    }
                    ret.ShakingNumberResultList = _shakingList;
                    ret.recordCount = _shakingNumberBLL.GetModels(x => x.ProjectGroupID == req.ProjectGroupID).Count();
                }
            }
            catch(Exception ex)
            {
                Logger.LogException("获取摇号结果列表发生异常！", "GetShakingNumbersController", "Post", ex);
                ret.code = 999;
                ret.errMsg = ex.Message;
            }
            return ret;
        }
    }
}
