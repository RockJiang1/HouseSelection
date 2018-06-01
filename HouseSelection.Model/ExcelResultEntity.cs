using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Model
{
    public class ExcelResultEntity:BaseResultEntity
    {
        public ExcelResultEntity()
        {
            this.SheetNumber = 0;
            this.SheetName = new List<SheetName>();
        }
        public int SheetNumber { get; set; }

        public List<SheetName> SheetName { get; set; }
    }

    public class SheetName
    {
        public string Name { get; set; }
    }
}
