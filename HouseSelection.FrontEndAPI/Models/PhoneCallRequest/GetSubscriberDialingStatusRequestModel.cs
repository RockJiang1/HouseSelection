using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSelection.FrontEndAPI.Models.PhoneCallRequest
{
    public class GetSubscriberDialingStatusRequestModel
    {
        public int ProjectId { get; set; }

        public int GroupId { get; set; }

        /// <summary>
        /// eg:
        /// 100-200,201-300,...,600-900
        /// </summary>
        public List<string> NumberRegions { get; set; }
    }
}