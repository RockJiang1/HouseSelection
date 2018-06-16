using HouseSelection.BLL;
using HouseSelection.FrontEndAPI.Models.PhoneCallRequest;
using HouseSelection.FrontEndAPI.Models.PhoneCallResult;
using HouseSelection.LoggerHelper;
using HouseSelection.Model;
using HouseSelection.Authorize;
using HouseSelection.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HouseSelection.FrontEndAPI.Controllers.PhoneCall
{
    public class GetSubscriberDialingStatusController:ApiController
    {
        ShakingNumberResultBLL _shakingNumberResultBLL = new ShakingNumberResultBLL();
        SubscriberBLL _subscriberBLL = new SubscriberBLL();
        SubscriberProjectMappingBLL _subscriberProjectMappingBLL = new SubscriberProjectMappingBLL();

        [ApiAuthorize]
        public GetSubscriberDialingStatusResultEntity Post(GetSubscriberDialingStatusRequestModel req)
        {
            Logger.LogInfo("GetSubscriberDialingStatus Request:" + JsonHelper.SerializeObject(req), "GetSubscriberDialingStatusController", "Post");
            var ret = new GetSubscriberDialingStatusResultEntity()
            {
                Code = 0,
                ErrMsg = string.Empty,
                Notconnected = new List<NotconnectedInfo>(),
                Undialed = new List<UndialedInfo>()
            };

            try
            {
                // 1.获取未拨打列表
                var undialedList = _shakingNumberResultBLL.GetModels(i => i.ShakingNumberSequance >= req.BeginNumber && i.ShakingNumberSequance <= req.EndNumber
                    && i.NoticeTime == 0).ToList();
                if (undialedList != null)
                {
                    int uindex = 1;
                    undialedList.ForEach(i => 
                    {
                        var sInfo = GetSubscriberBySPMId(i.SubscriberProjectMappingID);
                        if (sInfo != null)
                        {
                            ret.Undialed.Add(new UndialedInfo()
                            {
                                 Name= sInfo.Name,
                                  Phone = sInfo.Telephone,
                                   Sequence = uindex
                            });
                            uindex++;
                        }
                        else
                        {
                            var warningmsg = string.Format("根据SubscriberProjectMappingId {0} ，没有查询到相关认购人信息", i.SubscriberProjectMappingID);
                            ret.ErrMsg = ret.ErrMsg + "/n" + warningmsg;
                            Logger.LogWarning(warningmsg, "GetSubscriberDialingStatusController", "Post");
                        }
                    });
                }
                // 2.获取未接通列表
                var notConectedList = _shakingNumberResultBLL.GetModels(i => i.SelectHouseSequance >= req.BeginNumber && i.SelectHouseSequance <= req.EndNumber
                    && i.NoticeTime > 0 && !i.IsContacted).ToList();
                if (notConectedList != null)
                {
                    int nindex = 1;
                    notConectedList.ForEach(i =>
                    {
                        var sInfo = GetSubscriberBySPMId(i.SubscriberProjectMappingID);
                        if (sInfo != null)
                        {
                            ret.Notconnected.Add(new NotconnectedInfo()
                            {
                                CallTimes = i.NoticeTime,
                                LastCallTime = i.LastUpdate ?? i.CreateTime,
                                Name = sInfo.Name,
                                Sequence = nindex,
                                Phone = sInfo.Telephone
                            });
                            nindex++;
                        }
                        else
                        {
                            var warningmsg = string.Format("根据SubscriberProjectMappingId {0} ，没有查询到相关认购人信息", i.SubscriberProjectMappingID);
                            ret.ErrMsg = ret.ErrMsg+ "/n" + warningmsg;
                            Logger.LogWarning(warningmsg, "GetSubscriberDialingStatusController", "Post");
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                Logger.LogException("获取认购人电话拨打情况时发生异常！", "GetSubscriberDialingStatusController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }

            return ret;
        }

        private Subscriber GetSubscriberBySPMId(int spmId)
        {
            Subscriber result = new Subscriber();
            var smInfo = _subscriberProjectMappingBLL.GetModels(sm => sm.ID == spmId).FirstOrDefault();
            if (smInfo != null)
            {
                result = _subscriberBLL.GetModels(s => s.ID == smInfo.SubscriberID).FirstOrDefault();
            }
            else
            {
                result = null;
            }
            return result;
        }
    }
}