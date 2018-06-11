using HouseSelection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseSelection.FrontEndAPI.Models.PublicityResult
{
    public class GetHouseSelectPeriodResultEntity:BaseResultEntity
    {
        public List<PeriodEntity> Periods { get; set; }
        
    }

    public class PeriodEntity
    {
        /// <summary>
        /// 日期 MM.dd
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// 开始时间 hh:mm:ss
        /// </summary>
        public string BeginTime { get; set; }

        /// <summary>
        /// 结束时间 hh:mm:ss
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// 组
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// 号码
        /// </summary>
        public string Number { get; set; }
    }
}