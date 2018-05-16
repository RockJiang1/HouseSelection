using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Authorize
{
    public class TokenEntity
    {
        public int ID { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public Nullable<int> Identity { get; set; }
        public Nullable<int> RequestType { get; set; }
        public string RequestAccount { get; set; }
        public Nullable<System.Guid> RequestUserId { get; set; }
        public int Status { get; set; }
        public int Expiry { get; set; }
        public System.DateTime ExpiryDate { get; set; }
        public System.DateTime CreateTime { get; set; }
    }
}
