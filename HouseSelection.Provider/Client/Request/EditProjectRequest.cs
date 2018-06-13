using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.NetworkHelper;

namespace HouseSelection.Provider.Client.Request
{
    public class EditProjectRequest : GeneralRequest
    {
        protected override string APIAddress
        {
            get { return "/api/EditProject"; }
        }

        public override PostRequestContentType ContentType
        {
            get { return PostRequestContentType.Json; }
        }
        /// <summary>
        /// ERP门店ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// ERP门店ID
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// ERP门店ID
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// erp方门店id 最大长度100
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// erp方门店id 最大长度100
        /// </summary>
        public string ProjectArea { get; set; }
        /// <summary>
        /// 开发企业
        /// </summary>
        public string DevelopCompany { get; set; }

        /// <summary>
        /// 预售证号
        /// </summary>
        public string IdentityNumber { get; set; }

        /// <summary>
        /// 项目是否结束
        /// </summary>
        public bool IsEnd { get; set; }

        /// <summary>
        /// 项目结束原因
        /// </summary>
        public string EndReason { get; set; }
    }
}




