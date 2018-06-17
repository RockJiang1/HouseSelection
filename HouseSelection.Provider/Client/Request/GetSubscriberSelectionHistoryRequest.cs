using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.NetworkHelper;

namespace HouseSelection.Provider.Client.Request
{
    public class GetSubscriberSelectionHistoryRequest : GeneralRequest
    {
        protected override string APIAddress
        {
            get { return "/api/GetSubscriberSelectionHistory"; }
        }

        public override PostRequestContentType ContentType
        {
            get { return PostRequestContentType.Json; }
        }

        /// <summary>
        /// ERP门店ID
        /// </summary>
        public int SubscriberID { get; set; }
    }
}




