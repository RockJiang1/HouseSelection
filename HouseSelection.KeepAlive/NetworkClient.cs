using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.NetworkHelper;
using Newtonsoft.Json;

namespace HouseSelection.KeepAlive
{
    public class NetworkClient : BaseClient
    {
        protected override string CreateQueryString(BaseRequest req)
        {
            string test = JsonConvert.SerializeObject(req);

            return UnicodeHelper.ToJSUnicode(JsonConvert.SerializeObject(req, new JsonSerializerSettings()
            {
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
            }));
        }
    }
}
