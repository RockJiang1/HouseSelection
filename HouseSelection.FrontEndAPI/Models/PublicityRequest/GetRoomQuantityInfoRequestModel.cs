using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSelection.FrontEndAPI.Models.PublicityRequest
{
    public class GetRoomQuantityInfoRequestModel
    {
        // 项目id
        public int ProjectId { get; set; }

        // 楼盘id
        public int HouseEstateId { get; set; }
    }
}