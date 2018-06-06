using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSelection.FrontEndAPI.Models.PublicityRequest
{
    public class GetHouseBuildingsRequestModel
    {
        /// <summary>
        /// 项目id
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// 楼盘id
        /// </summary>
        public int HouseEstateId { get; set; }
    }
}