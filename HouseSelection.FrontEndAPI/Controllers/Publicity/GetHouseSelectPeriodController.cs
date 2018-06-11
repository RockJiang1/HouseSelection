using HouseSelection.BLL;
using HouseSelection.FrontEndAPI.Models.PublicityRequest;
using HouseSelection.FrontEndAPI.Models.PublicityResult;
using HouseSelection.LoggerHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HouseSelection.FrontEndAPI.Controllers.Publicity
{
    public class GetHouseSelectPeriodController:ApiController
    {
        // 1.获取当前项目下所有分组
        // 2.获取分组下所有的摇号结果
        // 3.获取同一分组下的摇号时间段。
        ProjectGroupBLL _projectGroupBLL = new ProjectGroupBLL();
        ShakingNumberResultBLL _shakingNumberResultBLL = new ShakingNumberResultBLL();
        HouseSelectPeriodBLL _houseSelectPeriodBLL = new HouseSelectPeriodBLL();

        public GetHouseSelectPeriodResultEntity Post(GetHouseSelectPeriodRequestModel req)
        {
            GetHouseSelectPeriodResultEntity ret = new GetHouseSelectPeriodResultEntity()
            {
                Code = 0,
                ErrMsg = string.Empty,
                Periods = new List<PeriodEntity>()
            };

            try
            {
                var projectGroups = _projectGroupBLL.GetModels(i => i.ProjectID == req.ProjectId).ToList();

                foreach (var i in projectGroups)
                {
                    var shakingNumberResult = _shakingNumberResultBLL.GetModels(s => s.ProjectGroupID == i.ID).OrderBy(s => s.ShakingNumberSequance).ToList();
                    if (shakingNumberResult.Count == 0)
                    {
                        Logger.LogWarning(string.Format("项目分组{0}下没有找到摇号结果。跳过此分组。", i.ID), "GetHouseSelectPeriodController", "Post");
                        continue;
                    }
                    var shakingNumberIds = shakingNumberResult.Select(si => si.ID);
                    var beginNumber = shakingNumberResult.Min(bn => bn.ShakingNumberSequance);
                    var endNumber = shakingNumberResult.Max(en => en.ShakingNumberSequance);
                    var periodsTimes = _houseSelectPeriodBLL.GetModels(hsp => shakingNumberIds.Contains(hsp.ShakingNumberResultID)).ToList();
                    var startDateTime = periodsTimes.Min(bt => bt.StartTime);
                    var endDateTime = periodsTimes.Max(mt => mt.EndTime);

                    var date = startDateTime.Date;
                    var startTime = startDateTime.TimeOfDay;
                    var endTime = endDateTime.TimeOfDay;

                    PeriodEntity periodInfo = new PeriodEntity()
                    {
                        Date = string.Format("{0}.{1}", date.Month, date.Day),
                        BeginTime = string.Format("{0}:{1}", startTime.Hours, startTime.Minutes),
                        EndTime = endTime.Hours.ToString() + ":" + endTime.Minutes.ToString(),
                        GroupId = i.ProjectGroupName,
                        Number = string.Format("{0}-{1}", beginNumber, endNumber)
                    };
                    ret.Periods.Add(periodInfo);
                }
            }
            catch (Exception ex)
            {
                Logger.LogException("获取项目时间段发生异常！", "GetHouseSelectPeriodController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
                ret.Periods = null;
            }

            return ret;
        }
    }
}