using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSelection.FrontEndAPI.Models.SelectHouseRequest
{
    public class GetValidHousesRequestModel
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

        /// <summary>
        /// 摇号结果ID
        /// </summary>
        public int ShakingNumberResultId { get; set; }
    }
}