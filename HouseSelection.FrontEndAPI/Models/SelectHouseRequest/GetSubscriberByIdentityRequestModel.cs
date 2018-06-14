using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSelection.FrontEndAPI.Models
{
    public class GetSubscriberByIdentityRequestModel
    {
        public int ProjectID { get; set; }
        public string IdentityNumber { get; set; }
    }
}