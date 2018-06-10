using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Model
{
    public class FrontEndAccountEntity
    {
        public int AccountID { get; set; }
        
        public string Account { get; set; }
        public List<AccountProjectEntity> ProjectList { get; set; }
    }
}
