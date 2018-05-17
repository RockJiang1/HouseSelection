using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Model
{
    public class TokenResultEntity
    {
        public int Code { get; set; }
        public string Access_Token { get; set; }
        public int Expiry { get; set; }
        public string ErrMsg { get; set; }
    }
}
