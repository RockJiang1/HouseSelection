using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using HouseSelection.NetworkHelper;

namespace HouseSelection.KeepAlive
{
    public class FrontEndAPIRequest : BaseRequest
    {
        protected override string APIAddress
        {
            get { return "/api/KeepAlive/"; }
        }

        public override FormMethods FormMethod
        {
            get { return FormMethods.Post; }
        }

        protected override string BaseUrl
        {
            get { return ConfigurationManager.AppSettings["FrontEndAPIURL"]; }
        }

        public override PostRequestContentType ContentType
        {
            get { return PostRequestContentType.Json; }
        }
    }
}
