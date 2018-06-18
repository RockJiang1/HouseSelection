using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.Model;

namespace HouseSelection.Provider.Client.Response
{
    public class GetSelectTimePeriodResponse : BaseResultEntity
    {
        public GetSelectTimePeriodResponse()
        {
            this.SelectTimeList = new List<SelectTimePeriodEntityTemp>();
        }
        /// <summary>
        /// 房源ID
        /// </summary>
        public List<SelectTimePeriodEntityTemp> SelectTimeList { get; set; }
    }

    public class SelectTimePeriodEntityTemp
    {
        /// <summary>
        /// ERP门店ID
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// erp方门店id 最大长度100
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// erp方门店id 最大长度100
        /// </summary>
        public int StartNumber { get; set; }
        /// <summary>
        /// 开发企业
        /// </summary>
        public int EndNumber { get; set; }
    }

    public class SelectTimePeriodSource
    {
        public int No { get; set; }
        /// <summary>
        /// ERP门店ID
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// erp方门店id 最大长度100
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// erp方门店id 最大长度100
        /// </summary>
        public int StartNumber { get; set; }
        /// <summary>
        /// 开发企业
        /// </summary>
        public int EndNumber { get; set; }
        public string Operate { get; set; }
    }

    public class SelectTimePeriodDtlSource
    {
        public int No { get; set; }
        /// <summary>
        /// ERP门店ID
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// erp方门店id 最大长度100
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// erp方门店id 最大长度100
        /// </summary>
        public int StartNumber { get; set; }
        /// <summary>
        /// 开发企业
        /// </summary>
        public int EndNumber { get; set; }
    }
}
