using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HouseSelection.Model;

namespace HouseSelection.FrontEndAPI.Models.SelectHouseResult
{
    public class GetValidBuildingsResultEntity : BaseResultEntity
    {
        /// <summary>
        /// 楼号列表
        /// </summary>
        public List<int> Buildings { get; set; }
    }
}