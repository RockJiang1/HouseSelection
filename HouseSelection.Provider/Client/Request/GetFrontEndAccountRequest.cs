using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.NetworkHelper;

namespace HouseSelection.Provider.Client.Request
{
    public class GetFrontEndAccountRequest : GeneralRequest
    {
        protected override string APIAddress
        {
            get { return "/api/GetFrontEndAccount"; }
        }

        public override PostRequestContentType ContentType
        {
            get { return PostRequestContentType.Json; }
        }
        public int ProjectID { get; set; }
        public string SearchStr { get; set; }
        /// <summary>
        /// ERP门店ID
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// erp方门店id 最大长度100
        /// </summary>
        public int PageIndex { get; set; }
    }
}
