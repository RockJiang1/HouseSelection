using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSelection.PrivateAPI.Models
{
    public class AddFrontEndAccountRequestModel
    {
        public int ProjectID { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
    }
}