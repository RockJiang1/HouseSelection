﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HouseSelection.Model;
using HouseSelection.PrivateAPI.Models;
using HouseSelection.BLL;
using HouseSelection.Authorize;
using HouseSelection.LoggerHelper;
using HouseSelection.Utility;

namespace HouseSelection.PrivateAPI.Controllers
{
    /// <summary>
    /// 分页获取所有楼盘信息
    /// </summary>
    public class GetAllHouseEstateInfoController : ApiController
    {
        private HouseEstateBLL _houseEstateBLL = new HouseEstateBLL();

        [ApiAuthorize]
        public GetHouseEstateResultEntity Post(BaseRequestModel Req)
        {
            Logger.LogDebug("GetAllHouseEstateInfo Request:" + JsonHelper.SerializeObject(Req), "GetAllHouseEstateInfoController", "Post");
            var ret = new GetHouseEstateResultEntity()
            {
                Code = 0,
                ErrMsg = ""
            };
            try
            {
                var _houseEstateList = _houseEstateBLL.GetModelsByPage(Req.PageSize, Req.PageIndex, true, p => p.ID, x => 1 == 1);
                var _hseList = new List<HouseEstateEntity>();
                foreach (var DBhe in _houseEstateList)
                {
                    var he = new HouseEstateEntity()
                    {
                        HouseEstateID = DBhe.ID,
                        ProjectNumber = DBhe.Project.Number,
                        ProjectName = DBhe.Project.Name,
                        HouseEstateName = DBhe.Name
                    };
                    _hseList.Add(he);
                }
                ret.HouseEstateList = _hseList;
                ret.RecordCount = _houseEstateBLL.GetModels(x => 1 == 1).Count();
            }
            catch(Exception ex)
            {
                Logger.LogException("获取所有楼盘信息时发生异常！", "GetAllHouseEstateInfoController", "Post", ex);
                ret.Code = 999;
                ret.ErrMsg = ex.Message;
            }
            return ret;
        }
    }
}
