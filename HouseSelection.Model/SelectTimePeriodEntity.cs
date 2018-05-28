using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Model
{
    public class SelectTimePeriodEntity
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// 开始号
        /// </summary>
        public int StartNumber { get; set; }

        /// <summary>
        /// 结束号
        /// </summary>
        public int EndNumber { get; set; }
    }
}
