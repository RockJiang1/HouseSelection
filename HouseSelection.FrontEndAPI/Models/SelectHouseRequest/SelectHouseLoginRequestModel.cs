using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSelection.FrontEndAPI.Models.SelectHouseRequest
{
    public class SelectHouseLoginRequestModel
    {
        public string LoginAccount { get; set; }

        public string LoginPassword { get; set; }
    }
}