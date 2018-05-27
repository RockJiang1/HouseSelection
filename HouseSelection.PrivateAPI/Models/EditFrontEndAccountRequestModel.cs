using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSelection.PrivateAPI.Models
{
    public class EditFrontEndAccountRequestModel
    {
        /// <summary>
        /// 账号ID
        /// </summary>
        public int AccountID { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 原密码
        /// </summary>
        public string BeforePassword { get; set; }

        /// <summary>
        /// 新密码
        /// </summary>
        public string Password { get; set; }
    }
}