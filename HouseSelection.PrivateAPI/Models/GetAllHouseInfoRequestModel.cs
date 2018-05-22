using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSelection.PrivateAPI.Models
{
    public class GetAllHouseInfoRequestModel : BaseRequestModel
    {
        public int HouseEstateID { get; set; }
    }
}