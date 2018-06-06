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

namespace HouseSelection.PrivateAPI.Controllers.SelectTimePeriod
{
    /// <summary>
    /// 创建时间段
    /// </summary>
    public class AddSelectTimePeriodController : ApiController
    {
        private ProjectGroupBLL _projectGroupBLL = new ProjectGroupBLL();
        private ShakingNumberResultBLL _shakeNumberBLL = new ShakingNumberResultBLL();
        private HouseSelectPeriodBLL _selectPeriodBLL = new HouseSelectPeriodBLL();

        [ApiAuthorize]
        public BaseResultEntity Post(AddSelectTimePeriodRequestEntity req)
        {
            Logger.LogDebug("AddSelectTimePeriod Request:" + JsonHelper.SerializeObject(req), "AddSelectTimePeriodController", "Post");
            var ret = new BaseResultEntity()
            {
                Code = 0,
                ErrMsg = ""
            };

            try
            {
                #region 数据校验
                if(_projectGroupBLL.GetModels(x => x.ID == req.ProjectGroupID).FirstOrDefault() == null)
                {
                    ret.Code = 301;
                    ret.ErrMsg = "项目分组ID不存在";
                }
                else if (_selectPeriodBLL.GetModels(x => x.ShakingNumberResult.ProjectGroupID == req.ProjectGroupID).FirstOrDefault() != null)//已存在
                {
                    ret.Code = 705;
                    ret.ErrMsg = "该项目分组已经创建过选房时间段，请使用修改模块！";
                }
                else
                {
                    var arryReq = req.SelectTimeList.OrderBy(x => x.StartNumber).ToArray();
                    for(int i = 0; i < arryReq.Length; i++) //校验号段不重复
                    {
                        if(arryReq[i].StartNumber > arryReq[i].EndNumber)
                        {
                            ret.Code = 701;
                            ret.ErrMsg = "一个时段内开始号段不得大于结束号段";
                            return ret;
                        }
                        if(i > 0)
                        {
                            if(arryReq[i].StartNumber <= arryReq[i - 1].EndNumber)
                            {
                                ret.Code = 703;
                                ret.ErrMsg = "号段存在重复";
                                return ret;
                            }
                        }
                    }

                    var arryTimeReq = req.SelectTimeList.OrderBy(x => Convert.ToDateTime(x.StartTime)).ToArray();
                    for (int i = 0; i < arryTimeReq.Length; i++) //校验时段不重复
                    {
                        if (Convert.ToDateTime(arryTimeReq[i].StartTime) > Convert.ToDateTime(arryTimeReq[i].EndTime))
                        {
                            ret.Code = 702;
                            ret.ErrMsg = "一个时段内开始时间不得大于结束号段";
                            return ret;
                        }
                        if (i > 0)
                        {
                            if (Convert.ToDateTime(arryTimeReq[i].StartTime) < Convert.ToDateTime(arryTimeReq[i - 1].EndTime))
                            {
                                ret.Code = 704;
                                ret.ErrMsg = "时间存在重复";
                                return ret;
                            }
                        }
                    }
                    #endregion

                    var _existList = new List<int>();
                    var _dbTimePeriodList = new List<HouseSelectPeriod>();
                    foreach(var timePeriod in req.SelectTimeList)
                    {
                        var _dbShakeNumberList = _shakeNumberBLL.GetModels(x => x.ProjectGroupID == req.ProjectGroupID && x.ShakingNumberSequance >= timePeriod.StartNumber && x.ShakingNumberSequance <= timePeriod.EndNumber).ToList();
                        foreach(var _dbNumber in _dbShakeNumberList)
                        {
                            if(_selectPeriodBLL.GetModels(x => x.ShakingNumberResultID == _dbNumber.ID).FirstOrDefault() != null) //已存在
                            {
                                _existList.Add(_dbNumber.ShakingNumberSequance);
                            }
                            else
                            {
                                var _timePeriod = new HouseSelectPeriod()
                                {
                                    ShakingNumberResultID = _dbNumber.ID,
                                    StartTime = Convert.ToDateTime(timePeriod.StartTime),
                                    EndTime = Convert.ToDateTime(timePeriod.EndTime),
                                    CreateTime = DateTime.Now,
                                    LastUpdate = DateTime.Now
                                };
                                _dbTimePeriodList.Add(_timePeriod);
                            }
                        }
                    }
                    _selectPeriodBLL.AddRange(_dbTimePeriodList);
                    if(_existList.Count > 0)
                    {
                        string existStr = "";
                        foreach(int s in _existList)
                        {
                            existStr += s.ToString() + ",";
                        }
                        existStr = existStr.Substring(0, existStr.Length - 1);
                        ret.ErrMsg = "已跳过存在的选房顺序号：" + existStr;
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogException("创建项目分组时间段时发生异常！", "AddSelectTimePeriodController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }
            return ret;
        }
    }
}
