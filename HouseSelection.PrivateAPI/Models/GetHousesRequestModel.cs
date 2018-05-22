using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSelection.PrivateAPI.Models
{
    public class GetHousesRequestModel : SearchRequestModel
    {
        public int HouseEstateID { get; set; }
    }
}