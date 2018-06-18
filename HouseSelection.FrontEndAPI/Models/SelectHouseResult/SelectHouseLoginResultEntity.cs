using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HouseSelection.Model;

namespace HouseSelection.FrontEndAPI.Models.SelectHouseResult
{
    public class SelectHouseLoginResultEntity : BaseResultEntity
    {
        public FrontEndAccountEntity AcountProjectInfo { get; set; }
        public TokenResultEntity Token { get; set; }
    }
}