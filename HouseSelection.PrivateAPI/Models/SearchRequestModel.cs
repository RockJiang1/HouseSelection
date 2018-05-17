using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSelection.PrivateAPI.Models
{
    public class SearchRequestModel : BaseRequestModel
    {
        public string SearchStr { get; set; }
    }
}