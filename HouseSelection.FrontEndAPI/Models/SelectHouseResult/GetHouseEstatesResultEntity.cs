using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HouseSelection.Model;

namespace HouseSelection.FrontEndAPI.Models.SelectHouseResult
{
    public class GetHouseEstatesResultEntity : BaseResultEntity
    {
        public List<HouseEstateEntity> HouseEstates { get; set; }
    }
}