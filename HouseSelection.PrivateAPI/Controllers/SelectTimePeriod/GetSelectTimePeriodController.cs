﻿using System;
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
    /// <summary>
    /// 获取选房时间段
    /// </summary>
    public class GetSelectTimePeriodController : ApiController
    {
        ProjectGroupBLL _projectGroupBLL = new ProjectGroupBLL();
        HouseSelectPeriodBLL _periodBLL = new HouseSelectPeriodBLL();

        [ApiAuthorize]
        public GetSelectTimePeriodResultEntity Post(GetSelectTimePeriodRequestModel req)
        {
            Logger.LogDebug("GetSelectTimePeriod Request:" + JsonHelper.SerializeObject(req), "GetSelectTimePeriodController", "Post");
            var ret = new GetSelectTimePeriodResultEntity()
            {
                Code = 0,
                ErrMsg = ""
            };

            try
            {
                if(_projectGroupBLL.GetModels(x => x.ID == req.ProjectGroupID).FirstOrDefault() == null)
                {
                    ret.Code = 202;
                    ret.ErrMsg = "项目分组ID不存在！";
                    return ret;
                }
                else
                {
                    var _dbPeriodList = _periodBLL.GetModels(x => x.ShakingNumberResult.ProjectGroupID == req.ProjectGroupID).ToList();
                    if(_dbPeriodList != null)
                    {
                        var _periodList = new List<SelectTimePeriodEntity>();
                        foreach(var _dbPeriod in _dbPeriodList)
                        {
                            var matchPeriod = _periodList.FirstOrDefault(x => x.StartTime == _dbPeriod.StartTime.ToString("yyyy-MM-dd HH:mm:ss") && x.EndTime == _dbPeriod.EndTime.ToString("yyyy-MM-dd HH:mm:ss"));
                            if (matchPeriod != null)
                            {
                                if(_dbPeriod.ShakingNumberResult.ShakingNumberSequance > matchPeriod.EndNumber)
                                {
                                    matchPeriod.EndNumber = _dbPeriod.ShakingNumberResult.ShakingNumberSequance;
                                }
                                else if(_dbPeriod.ShakingNumberResult.ShakingNumberSequance < matchPeriod.StartNumber)
                                {
                                    matchPeriod.StartNumber = _dbPeriod.ShakingNumberResult.ShakingNumberSequance;
                                }
                            }
                            else
                            {
                                var _period = new SelectTimePeriodEntity()
                                {
                                    StartTime = _dbPeriod.StartTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                    EndTime = _dbPeriod.EndTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                    StartNumber = _dbPeriod.ShakingNumberResult.ShakingNumberSequance,
                                    EndNumber = _dbPeriod.ShakingNumberResult.ShakingNumberSequance,
                                };
                                _periodList.Add(_period);
                            }
                        }
                        ret.SelectTimeList = _periodList.OrderBy(x => x.StartNumber).ToList();
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogException("", "", "", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }
            return ret;
        }
    }
}
