using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Model
{
    public class GetSelectionDetailResultEntity : BaseResultEntity
    {
        /// <summary>
        /// 房源对象
        /// </summary>
        public HouseEntity House { get; set; }

        /// <summary>
        /// 选房时间
        /// </summary>
        public DateTime SelectTime { get; set; }

        /// <summary>
        /// 选房照片1
        /// </summary>
        public string SelectImageUrl1 { get; set; }

        /// <summary>
        /// 选房照片2
        /// </summary>
        public string SelectImageUrl2 { get; set; }

        /// <summary>
        /// 选房照片3
        /// </summary>
        public string SelectImageUrl3 { get; set; }

        /// <summary>
        /// 是否弃选
        /// </summary>
        public bool IsAbandon { get; set; }

        /// <summary>
        /// 弃选时间
        /// </summary>
        public DateTime? AbandonTime { get; set; }

        /// <summary>
        /// 弃选照片1
        /// </summary>
        public string AbandonImageUrl1 { get; set; }

        /// <summary>
        /// 弃选照片2
        /// </summary>
        public string AbandonImageUrl2 { get; set; }

        /// <summary>
        /// 弃选照片3
        /// </summary>
        public string AbandonImageUrl3 { get; set; }
    }
}
