using HouseSelection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSelection.FrontEndAPI.Models.PublicityResult
{
    public class GetHouseEstatesByProjectResultEntity:BaseResultEntity
    {
        public List<HouseEstateEntity> HouseEstates { get; set; }
    }
}