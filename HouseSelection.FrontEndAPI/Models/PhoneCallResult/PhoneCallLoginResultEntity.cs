using HouseSelection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSelection.FrontEndAPI.Models.PhoneCallResult
{
    public class PhoneCallLoginResultEntity:BaseResultEntity
    {
        public FrontEndAccountEntity AcountProjectInfo { get; set; }
    }
}