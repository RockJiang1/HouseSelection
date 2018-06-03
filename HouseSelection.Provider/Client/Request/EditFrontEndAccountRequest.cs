using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.NetworkHelper;

namespace HouseSelection.Provider.Client.Request
{
    public class EditFrontEndAccountRequest : GeneralRequest
    {
        protected override string APIAddress
        {
            get { return "/api/EditFrontEndAccount"; }
        }

        public override PostRequestContentType ContentType
        {
            get { return PostRequestContentType.Json; }
        }

        /// <summary>
        /// ERP门店ID
        /// </summary>
        public int AccountID { get; set; }
        /// <summary>
        /// ERP门店ID
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// erp方门店id 最大长度100
        /// </summary>
        public string BeforePassword { get; set; }
        public string Password { get; set; }
    }
}
}
