using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Model
{
    public class AreaEntity
    {
        /// <summary>
        /// 自增id
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 区域名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { get; set; }
    }
}
