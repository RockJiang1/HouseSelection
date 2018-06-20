using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HouseSelection.Model;

namespace HouseSelection.FrontEndAPI.Models.PhoneCallResult
{
    public class SaveNotifyRecordsResultEntity : BaseResultEntity
    {
        public DialedInfo DialedInfo { get; set; }
    }
}