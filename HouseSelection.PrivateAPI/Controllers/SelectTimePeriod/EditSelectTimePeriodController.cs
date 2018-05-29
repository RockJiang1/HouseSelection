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

namespace HouseSelection.PrivateAPI.Controllers.SelectTimePeriod
{
    /// <summary>
    /// 修改时间段
    /// </summary>
    public class EditSelectTimePeriodController : ApiController
    {
        private ProjectGroupBLL _projectGroupBLL = new ProjectGroupBLL();
        private ShakingNumberResultBLL _shakeNumberBLL = new ShakingNumberResultBLL();
        private HouseSelectPeriodBLL _selectPeriodBLL = new HouseSelectPeriodBLL();

        [ApiAuthorize]
        public BaseResultEntity Post(AddSelectTimePeriodRequestEntity req)
        {
            var ret = new BaseResultEntity()
            {
                code = 0,
                errMsg = ""
            };

            try
            {
                #region 数据校验
                if (_projectGroupBLL.GetModels(x => x.ID == req.ProjectGroupID).FirstOrDefault() == null)
                {
                    ret.code = 301;
                    ret.errMsg = "项目分组ID不存在";
                }
                else
                {
                    var arryReq = req.SelectTimeList.OrderBy(x => x.StartNumber).ToArray();
                    for (int i = 0; i < arryReq.Length; i++) //校验号段不重复
                    {
                        if (arryReq[i].StartNumber > arryReq[i].EndNumber)
                        {
                            ret.code = 701;
                            ret.errMsg = "一个时段内开始号段不得大于结束号段";
                            return ret;
                        }
                        if (i > 0)
                        {
                            if (arryReq[i].StartNumber <= arryReq[i - 1].EndNumber)
                            {
                                ret.code = 703;
                                ret.errMsg = "号段存在重复";
                                return ret;
                            }
                        }
                    }

                    var arryTimeReq = req.SelectTimeList.OrderBy(x => Convert.ToDateTime(x.StartTime)).ToArray();
                    for (int i = 0; i < arryTimeReq.Length; i++) //校验时段不重复
                    {
                        if (Convert.ToDateTime(arryTimeReq[i].StartTime) > Convert.ToDateTime(arryTimeReq[i].EndTime))
                        {
                            ret.code = 702;
                            ret.errMsg = "一个时段内开始时间不得大于结束号段";
                            return ret;
                        }
                        if (i > 0)
                        {
                            if (Convert.ToDateTime(arryTimeReq[i].StartTime) < Convert.ToDateTime(arryTimeReq[i - 1].EndTime))
                            {
                                ret.code = 703;
                                ret.errMsg = "时间存在重复";
                                return ret;
                            }
                        }
                    }
                    #endregion

                    var _dbExist = _selectPeriodBLL.GetModels(x => x.ShakingNumberResult.ProjectGroupID == req.ProjectGroupID).ToList();
                    _selectPeriodBLL.DeleteRange(_dbExist); //先删后插

                    var _existList = new List<int>();
                    var _dbTimePeriodList = new List<HouseSelectPeriod>();
                    foreach (var timePeriod in req.SelectTimeList)
                    {
                        var _dbShakeNumberList = _shakeNumberBLL.GetModels(x => x.ProjectGroupID == req.ProjectGroupID && x.ShakingNumberSequance >= timePeriod.StartNumber && x.ShakingNumberSequance <= timePeriod.EndNumber).ToList();
                        foreach (var _dbNumber in _dbShakeNumberList)
                        {
                            if (_selectPeriodBLL.GetModels(x => x.ShakingNumberResultID == _dbNumber.ID).FirstOrDefault() != null) //已存在
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
                    if (_existList.Count > 0)
                    {
                        string existStr = "";
                        foreach (int s in _existList)
                        {
                            existStr += s.ToString() + ",";
                        }
                        existStr = existStr.Substring(0, existStr.Length - 1);
                        ret.errMsg = "已跳过存在的选房顺序号：" + existStr;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException("创建项目分组时间段时发生异常！", "AddSelectTimePeriodController", "Post", ex);
                ret.code = 999;
                ret.errMsg = ex.Message;
            }
            return ret;
        }
    }
}
