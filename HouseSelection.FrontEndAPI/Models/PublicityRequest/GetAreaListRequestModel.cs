using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSelection.FrontEndAPI.Models.PublicityRequest
{
    public class GetAreaListRequestModel
    {
        /// <summary>
        /// 城市名称。
        /// 该参数有值时，返回该城市下的所有区域。
        /// 该参数为空时，返回所有区域。
        /// </summary>
        public string CityName { get; set; }
    }
}