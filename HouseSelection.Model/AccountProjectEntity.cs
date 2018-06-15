using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Model
{
    public class AccountProjectEntity
    {
        public int ProjectID { get; set; }
        public string ProjectNumber { get; set; }
        public string ProjectName { get; set; }
        public bool IsEnd { get; set; }
        public string EndReason { get; set; }
    }
}
