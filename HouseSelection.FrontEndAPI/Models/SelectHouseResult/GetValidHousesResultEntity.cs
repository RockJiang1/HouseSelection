using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HouseSelection.Model;

namespace HouseSelection.FrontEndAPI.Models.SelectHouseResult
{
    public class GetValidHousesResultEntity : BaseResultEntity
    {
        public List<HouseInfo> Houses { get; set; }
    }

    public class HouseInfo
    {
        public int Building { get; set; }

        public int Unit { get; set; }

        public HouseEntity HouseDetail { get; set; }
    }
}