using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Model
{
    public class ProjectListResultEntity : BaseListResultEntity
    {
        /// <summary>
        /// 项目列表
        /// </summary>
        public List<ProjectEntity> ProjectList { get; set; }
    }
}
