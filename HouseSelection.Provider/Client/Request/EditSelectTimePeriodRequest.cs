using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.NetworkHelper;
using HouseSelection.Provider.Client.Response;

namespace HouseSelection.Provider.Client.Request
{
    public class EditSelectTimePeriodRequest : GeneralRequest
    {
        protected override string APIAddress
        {
            get { return "/api/EditSelectTimePeriod"; }
        }

        public override PostRequestContentType ContentType
        {
            get { return PostRequestContentType.Json; }
        }

        public EditSelectTimePeriodRequest()
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



