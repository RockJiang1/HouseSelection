using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSelection.PrivateAPI.Models
{
    public class CloseProjectRequestModel
    {
        public int ProjectID { get; set; }
        public string EndReason { get; set; }
    }
}