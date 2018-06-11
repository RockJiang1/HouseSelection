using HouseSelection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSelection.FrontEndAPI.Models.PublicityResult
{
    public class GetRoomQuantityInfoResultEntity : BaseResultEntity
    {
        /// <summary>
        /// 总房间数
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// 已经被认购的房间数
        /// </summary>
        public int Used { get; set; }
    }
}