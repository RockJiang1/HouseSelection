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
        HouseSelectPeriodBLL _houseSelectPeriodBLL = new HouseSelectPeriodBLL();

        [ApiAuthorize]
        public GetSubscriberDialingStatusResultEntity Post(GetSubscriberDialingStatusRequestModel req)
        {
            Logger.LogInfo("GetSubscriberDialingStatus Request:" + JsonHelper.SerializeObject(req), "GetSubscriberDialingStatusController", "Post");
            var ret = new GetSubscriberDialingStatusResultEntity()
            {
                Code = 0,
                ErrMsg = string.Empty,
                DialedInfoList = new List<DialedInfo>()
            };

            try
            {
                // 1.组装条件
                if (req.ProjectId <= 0 || req.GroupId <= 0)
                {
                    ret.Code = 99;
                    ret.ErrMsg = "项目id或分组id参数异常！";
                    return ret;
                }

                List<ShakingNumberResult> results = new List<ShakingNumberResult>();

                int projectId = req.ProjectId;
                int groupId = req.GroupId;
                foreach (var region in req.NumberRegions)
                {
                    var regionSplits = region.Split('-');
                    int beginNumber;
                    int endNumber;
                    if (!int.TryParse(regionSplits[0], out beginNumber) || !int.TryParse(regionSplits[1], out endNumber))
                    {
                        ret.Code = 99;
                        ret.ErrMsg = "序号数据格式不正确，请检查!";
                        return ret;
                    }
                    else
                    {
                        results.AddRange(_shakingNumberResultBLL.GetModels(i => i.ShakingNumberSequance >= beginNumber && i.ShakingNumberSequance <= endNumber).ToList());
                    }
                }
                // 2.查找结果 拼接响应实体
                if (results != null && results.Count > 0)
                {
                    int index = 1;
                    results.ForEach(i =>
                    {
                        TimeSpan startTime;
                        TimeSpan endTime;
                        GetPeriodTimes(i.ID, out startTime, out endTime);
                        var subInfo = GetSubscriberBySPMId(i.SubscriberProjectMappingID);
                        if (subInfo != null)
                        {
                            var dialedInfo = new DialedInfo()
                            {
                                Sequence = index,
                                Name = subInfo.Name,
                                IdentityID = subInfo.IdentityNumber,
                                BeginTime = startTime,
                                EndTime = endTime,
                                CallTimes = i.NoticeTime,
                                IsNotConnected = !i.IsContacted,
                                IsUndialed = i.NoticeTime == 0,
                                LastCallTime = i.LastUpdate ?? i.CreateTime,
                                NotConnectedReason = string.Empty,
                                Phone = subInfo.Telephone
                            };
                            ret.DialedInfoList.Add(dialedInfo);
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

        private void GetPeriodTimes(int resultId, out TimeSpan begintime, out TimeSpan endtime)
        {
            begintime = new TimeSpan(0, 0, 0);
            endtime = new TimeSpan(0, 0, 0);
            var periodInfo = _houseSelectPeriodBLL.GetModels(i => i.ShakingNumberResultID == resultId).FirstOrDefault();
            if (periodInfo != null)
            {
                begintime = periodInfo.StartTime.TimeOfDay;
                endtime = periodInfo.EndTime.TimeOfDay;
            }
        }
    }
}