using HouseSelection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSelection.FrontEndAPI.Models.PublicityResult
{
    public class GetHouseBuildingsResultEntity:BaseResultEntity
    {
        /// <summary>
        /// 楼号列表
        /// </summary>
        public List<int> Buildings { get; set; } 
    }
}