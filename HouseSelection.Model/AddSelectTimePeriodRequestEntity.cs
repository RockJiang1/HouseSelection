using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Model
{
    public class AddSelectTimePeriodRequestEntity
    {
        public int ProjectGroupID { get; set; }
        public List<SelectTimePeriodEntity> SelectTimeList { get; set; }
    }
}
