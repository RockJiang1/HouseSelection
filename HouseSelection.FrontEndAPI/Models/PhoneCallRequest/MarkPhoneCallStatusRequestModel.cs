using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSelection.FrontEndAPI.Models.PhoneCallRequest
{
    public class MarkPhoneCallStatusRequestModel
    {
        public int ShakingResultNumberId { get; set; }
        
        public bool IsSendMessage { get; set; }

        public bool IsCallBack { get; set; }
    }
}