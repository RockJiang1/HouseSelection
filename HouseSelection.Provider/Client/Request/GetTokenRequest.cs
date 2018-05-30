using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.NetworkHelper;
using Newtonsoft.Json;

namespace HouseSelection.Provider.Client.Request
{
    public class GetTokenRequest : GeneralRequest
    {
        protected override string APIAddress
        {
            get { return "/api/Token"; }
        }

        public override PostRequestContentType ContentType
        {
            get { return PostRequestContentType.Json; }
        }

        /// <summary>
        /// ERP门店ID
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// erp方门店id 最大长度100
        /// </summary>
        public string AppSecret{ get; set; }

    }
}


