using HouseSelection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSelection.FrontEndAPI.Models.PhoneCallResult
{
    public class GetPhoneCallProjectGroupListResultEntity:BaseResultEntity
    {
        public List<PhoneCallProjectGroupInfo> ProjectGroupList { get; set; }

    }

    public class PhoneCallProjectGroupInfo
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public int BeginNumber { get; set; }

        public int EndNumber { get; set; }

        //public bool IsFinished { get; set; }
    }
}