using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Model
{
    public class BaseListResultEntity
    {
        public int code { get; set; }
        public string errMsg { get; set; }
        public int recordCount { get; set; }
    }
}
