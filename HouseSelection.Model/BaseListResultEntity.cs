using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Model
{
    public class BaseListResultEntity
    {
        public int Code { get; set; }
        public string ErrMsg { get; set; }
        public int RecordCount { get; set; }
    }
}
