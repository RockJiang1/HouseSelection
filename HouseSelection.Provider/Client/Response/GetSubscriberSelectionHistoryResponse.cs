using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.Model;

namespace HouseSelection.Provider.Client.Response
{
    public class GetSubscriberSelectionHistoryResponse : BaseResultEntity
    {
        public GetSubscriberSelectionHistoryResponse()
        {
            this.SelectionList = new List<SubscriberSelectionEntityTemp>();
        }
        /// <summary>
        /// 房源ID
        /// </summary>
        public List<SubscriberSelectionEntityTemp> SelectionList { get; set; }

        //public int RecordCount { get; set; }
    }

    public class SubscriberSelectionEntityTemp
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
        /// 弃选状态
        /// </summary>
        public int AbandonStatus { get; set; }

        /// <summary>
        /// 摇号结果ID(获取录音信息时使用)
        /// </summary>
        public int? ShakingResultID { get; set; }

        /// <summary>
        /// 选房ID(获取选房明细信息时使用)
        /// </summary>
        public int? SelectionID { get; set; }
    }

    public class SubscriberSelectionDetailData
    {
        public string Name { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        public string IdentityNumber { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// 选房ID(获取选房明细信息时使用)
        /// </summary>
        public int SelectionID { get; set; }
    }

    public class SubscriberSelectionSource
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
        /// 弃选状态
        /// </summary>
        public int AbandonStatus { get; set; }

        /// <summary>
        /// 摇号结果ID(获取录音信息时使用)
        /// </summary>
        public int? ShakingResultID { get; set; }

        /// <summary>
        /// 选房ID(获取选房明细信息时使用)
        /// </summary>
        public int? SelectionID { get; set; }

        public string Operate1 { get; set; }
        public string Operate2 { get; set; }
    }
}




