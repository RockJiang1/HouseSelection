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

        public int BeginNumber { get; set; }

        public int EndNumber { get; set; }
    }
}