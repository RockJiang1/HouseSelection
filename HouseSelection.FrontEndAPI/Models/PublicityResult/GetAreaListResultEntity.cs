using HouseSelection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSelection.FrontEndAPI.Models.PublicityResult
{
    public class GetAreaListResultEntity: BaseResultEntity
    {
        // 区域列表
        public List<AreaEntity> AreaList { get; set; }
    }
}