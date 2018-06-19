using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSelection.FrontEndAPI.Models.PhoneCallRequest
{
    public class SaveNotifyRecordsRequestModel
    {
        /// <summary>
        /// 前台登陆的账号
        /// </summary>
        public int FrontAccountId { get; set; }

        /// <summary>
        /// 打电话的人的手机
        /// </summary>
        public string NoticePhone { get; set; }

        public int ShakeNumberResultId { get; set; }
        
        public int ResultType { get; set; }
    }
}