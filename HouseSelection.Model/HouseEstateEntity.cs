using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Model
{
    public class HouseEstateEntity
    {
        /// <summary>
        /// 楼盘ID
        /// </summary>
        public int HouseEstateID { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        public string ProjectNumber { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// 楼盘名称
        /// </summary>
        public string HouseEstateName { get; set; }
    }
}
