using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Model
{
    public class ProjectEntity
    {
        /// <summary>
        /// 项目ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 项目地址
        /// </summary>
        public string Address { get; set; }
    }
}
