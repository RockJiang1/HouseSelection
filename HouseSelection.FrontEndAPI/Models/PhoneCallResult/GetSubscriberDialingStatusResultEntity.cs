using HouseSelection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HouseSelection.FrontEndAPI.Models.PhoneCallResult
{
    public class GetSubscriberDialingStatusResultEntity : BaseResultEntity
    {
        ///// <summary>
        ///// 未拨打列表
        ///// </summary>
        //public List<UndialedInfo> Undialed { get; set; }

        ///// <summary>
        ///// 未接通列表
        ///// </summary>
        //public List<NotconnectedInfo> Notconnected { get; set; }

        public List<DialedInfo> DialedInfoList { get; set; }
    }

    public class UndialedInfo
    {
        public int Sequence { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }
    }

    public class NotconnectedInfo
    {
        public int Sequence { get; set; }

        public string Name { get; set; }

        public int CallTimes { get; set; }

        public DateTime LastCallTime { get; set; }

        public string Phone { get; set; }
    }
}