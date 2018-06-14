using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HouseSelection.FrontEndAPI.Models;
using HouseSelection.BLL;
using HouseSelection.Authorize;
using HouseSelection.LoggerHelper;
using HouseSelection.Utility;

namespace HouseSelection.FrontEndAPI.Controllers
{
    /// <summary>
    /// 按身份证获取认购人信息
    /// </summary>
    public class GetSubscriberByIdentityController : ApiController
    {
        private ProjectBLL _projectBLL = new ProjectBLL();
        private HouseSelectPeriodBLL _selectPeriodBLL = new HouseSelectPeriodBLL();
        private ShakingNumberResultBLL _shakingBLL = new ShakingNumberResultBLL();

        [ApiAuthorize]
        public GetSubscriberByIdentityResultEntity Post(GetSubscriberByIdentityRequestModel req)
        {
            Logger.LogDebug("GetSubscriberByIdentity Request:" + JsonHelper.SerializeObject(req), "GetSubscriberByIdentityController", "Post");
            var ret = new GetSubscriberByIdentityResultEntity()
            {
                Code = 0,
                ErrMsg = ""
            };

            try
            {
                if(_projectBLL.GetModels(x => x.ID == req.ProjectID).FirstOrDefault() == null)
                {
                    ret.Code = 201;
                    ret.ErrMsg = "项目ID不存在！";
                }
                else
                {
                    var _dbShaking = _shakingBLL.GetModels(x => x.ProjectGroup.ProjectID == req.ProjectID && x.SubscriberProjectMapping.Subscriber.IdentityNumber == req.IdentityNumber).FirstOrDefault();
                    if(_dbShaking == null)
                    {
                        ret.Code = 202;
                        ret.ErrMsg = "认购人摇号信息不存在！";
                    }
                    else
                    {
                        var _dbPeriod = _selectPeriodBLL.GetModels(x => x.ShakingNumberResultID == _dbShaking.ID).FirstOrDefault();
                        if(_dbPeriod == null)
                        {
                            ret.Code = 203;
                            ret.ErrMsg = "认购人选房时间段不存在！";
                        }
                        else
                        {
                            ret.ShakingNumberResultID = _dbShaking.ID;
                            ret.Name = _dbShaking.SubscriberProjectMapping.Subscriber.Name;
                            ret.IdentityNumber = _dbShaking.SubscriberProjectMapping.Subscriber.IdentityNumber;
                            ret.ShakingNumberSequance = _dbShaking.ShakingNumberSequance;
                            ret.SelectHouseSequance = _dbShaking.SelectHouseSequance;
                            ret.ProjectGroup = _dbShaking.ProjectGroup.ProjectGroupName;
                            ret.StartSelectTime = _dbPeriod.StartTime.ToString("yyyy-MM-dd HH:mm:ss");
                            ret.EndSelectTime = _dbPeriod.EndTime.ToString("yyyy-MM-dd HH:mm:ss");
                            ret.IsAuthorized = _dbShaking.IsAuthorized ? 1 : 0;
                            ret.IsAgent = _dbShaking.IsAgent ? 1 : 0;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogException("按身份证获取认购人信息发生异常！", "GetSubscriberByIdentityController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }
            return ret;
        }
    }
}
