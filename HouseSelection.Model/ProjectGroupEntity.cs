using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Model
{
    public class ProjectGroupEntity
    {
        /// <summary>
        /// 项目ID
        /// </summary>
        public int ProjectID { get; set; }
        /// <summary>
        /// 项目编号
        /// </summary>
        public string ProjectNumber { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// 项目分组ID
        /// </summary>
        public int ProjectGroupID { get; set; }

        /// <summary>
        /// 项目分组名称
        /// </summary>
        
        public string ProjectGroupName { get; set; }
    }
}
