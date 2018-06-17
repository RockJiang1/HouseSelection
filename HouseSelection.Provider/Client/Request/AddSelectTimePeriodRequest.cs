using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.NetworkHelper;
using HouseSelection.Provider.Client.Response;

namespace HouseSelection.Provider.Client.Request
{
    public class AddSelectTimePeriodRequest : GeneralRequest
    {
        protected override string APIAddress
        {
            get { return "/api/AddSelectTimePeriod"; }
        }

        public override PostRequestContentType ContentType
        {
            get { return PostRequestContentType.Json; }
        }

        public AddSelectTimePeriodRequest()
        {
            this.SelectTimeList = new List<SelectTimePeriodEntityTemp>();
        }

        /// <summary>
        /// ERP门店ID
        /// </summary>
        public int ProjectGroupID { get; set; }
        /// <summary>
        /// ERP门店ID
        /// </summary>
        public List<SelectTimePeriodEntityTemp> SelectTimeList { get; set; }
    }
}



