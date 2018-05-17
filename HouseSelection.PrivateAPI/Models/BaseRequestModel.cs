using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSelection.PrivateAPI.Models
{
    public class BaseRequestModel
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}