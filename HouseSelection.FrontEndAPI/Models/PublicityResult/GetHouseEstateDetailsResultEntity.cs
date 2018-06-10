using HouseSelection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSelection.FrontEndAPI.Models.PublicityResult
{
    public class GetHouseEstateDetailsResultEntity:BaseResultEntity
    {
        /*
         *响应结果应该包含：
         * 1.每栋包括几个单元
         * 2.每个单元的房间详情
         */
         
        ///// <summary>
        ///// 单元列表
        ///// int-楼号
        ///// List<int>-单元列表
        ///// </summary>
        //public List<Unit> Units { get; set; }

        /// <summary>
        /// 房间列表
        /// </summary>
        public List<HouseInfo> Houses { get; set; }
    }

    public class Unit
    {
        public int BuildingId { get; set; }

        public List<int> Units { get; set; }
    }

    public class HouseInfo
    {
        public int Building { get; set; }

        public int Unit { get; set; }

        public HouseEntity HouseDetail { get; set; }
    }
}