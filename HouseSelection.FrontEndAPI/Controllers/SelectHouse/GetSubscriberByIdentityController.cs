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
        private ProjectGroupBLL _GroupBLL = new ProjectGroupBLL();
        private HouseSelectPeriodBLL _selectPeriodBLL = new HouseSelectPeriodBLL();
        private ShakingNumberResultBLL _shakingBLL = new ShakingNumberResultBLL();
        private HouseSelectionRecordBLL _selectRecordBLL = new HouseSelectionRecordBLL();

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
                            var _selectRecord = _selectRecordBLL.GetModels(x => x.IsAbandon == true && x.SubscriberID == _dbShaking.SubscriberProjectMapping.SubscriberID);
                            DateTime dt = DateTime.Now.AddMinutes(-30);
                            var _validPeriod = _selectPeriodBLL.GetModels(x => x.StartTime >= dt && x.EndTime <= DateTime.Now).FirstOrDefault();

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
                            if (_dbShaking.IsAuthorized)
                            {
                                ret.Hint = "该认购人已经身份审核过";
                            }
                            else if (_dbShaking.SubscriberProjectMapping.Subscriber.HouseSelectionRecord.Any(x => x.IsConfirm == true && x.IsAbandon == false))
                            {
                                ret.Hint = "该认购人已经确认选房";
                            }
                            else if(_dbShaking.SubscriberProjectMapping.Subscriber.HouseSelectionRecord.Any(x => x.IsAbandon == true))
                            {
                                ret.Hint = "该认购人已经在该项目中发生弃选";
                            }
                            else if(_selectRecord != null && _selectRecord.Count() >= 2)
                            {
                                ret.Hint = "该认购人历史弃选已次超过2次";
                            }
                            else if(_dbPeriod.StartTime < DateTime.Now.AddMinutes(-30) || _dbPeriod.EndTime > DateTime.Now)
                            {
                                ret.Hint = "该认购人不在选房时间段内，实际时间段为" + _dbPeriod.StartTime.ToString("yyyy-MM-dd HH:mm:ss") + " - " + _dbPeriod.EndTime.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            else if(_validPeriod.ShakingNumberResult.ProjectGroupID != _dbShaking.ProjectGroupID)
                            {
                                ret.Hint = "该认购人不属于该时段分组，实际分组为:" + _validPeriod.ShakingNumberResult.ProjectGroup.ProjectGroupName;
                            }
                            else
                            {
                                ret.Hint = "";
                            }
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
