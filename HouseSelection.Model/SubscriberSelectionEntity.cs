using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Model
{
    public class SubscriberSelectionEntity
    {
        /// <summary>
        /// 项目ID
        /// </summary>
        public int ProjectID { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        public string ProjectNumber { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// 通知状态
        /// </summary>
        public int NoticeStatus { get; set; }

        /// <summary>
        /// 身份认证状态
        /// </summary>
        public int AuthStatus { get; set; }

        /// <summary>
        /// 选房状态
        /// </summary>
        public int SelectionStatus { get; set; }

        /// <summary>
        /// 确认状态
        /// </summary>
        public int ConfirmStatus { get; set; }

        /// <summary>
        /// 摇号结果ID(获取录音信息时使用)
        /// </summary>
        public int? ShakingResultID { get; set; }
        
    }
}
