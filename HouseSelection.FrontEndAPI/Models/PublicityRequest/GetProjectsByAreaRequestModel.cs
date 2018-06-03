using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSelection.FrontEndAPI.Models.PublicityRequest
{
    public class GetProjectsByAreaRequestModel
    {
        /// <summary>
        /// 区域id
        /// 若为0，则返回全部项目
        /// </summary>
        public int AreaId { get; set; }

    }
}