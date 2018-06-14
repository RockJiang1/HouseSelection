using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HouseSelection.Model;

namespace HouseSelection.FrontEndAPI.Models
{
    public class GetSubscriberByIdentityResultEntity : BaseResultEntity
    {
        /// <summary>
        /// 摇号结果ID
        /// </summary>
        public int ShakingNumberResultID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdentityNumber { get; set; }

        /// <summary>
        /// 摇号顺序号
        /// </summary>
        public int ShakingNumberSequance { get; set; }

        /// <summary>
        /// 选房顺序号
        /// </summary>
        public int SelectHouseSequance { get; set; }

        /// <summary>
        /// 项目分组
        /// </summary>
        public string ProjectGroup { get; set; }

        /// <summary>
        /// 开始选房时间
        /// </summary>
        public string StartSelectTime { get; set; }

        /// <summary>
        /// 结束选房时间
        /// </summary>
        public string EndSelectTime { get; set; }

        /// <summary>
        /// 是否认证过
        /// </summary>
        public int IsAuthorized { get; set; }

        /// <summary>
        /// 是否为代理人
        /// </summary>
        public int IsAgent { get; set; }
    }
}