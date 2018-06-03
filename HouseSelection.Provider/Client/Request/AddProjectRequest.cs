using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.NetworkHelper;

namespace HouseSelection.Provider.Client.Request
{
    public class AddProjectRequest: GeneralRequest
    {
        protected override string APIAddress
        {
            get { return "/api/AddProject"; }
        }

        public override PostRequestContentType ContentType
        {
            get { return PostRequestContentType.Json; }
        }

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
    }
}



