using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSelection.FrontEndAPI.Models.PublicityRequest
{
    /// <summary>
    /// 获取楼盘明细请求实体
    /// 入参：项目id，楼盘id
    /// </summary>
    public class GetHouseEstateDetailsRequestModel
    {
        /// <summary>
        /// 项目id
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// 楼盘id
        /// </summary>
        public int HouseEstateId { get; set; }

        /// <summary>
        /// 楼号
        /// </summary>
        public int BuildingId { get; set; }
    }
}