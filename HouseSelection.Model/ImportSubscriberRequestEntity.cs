using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Model
{
    public class ImportSubscriberRequestEntity
    {
        /// <summary>
        /// 项目ID
        /// </summary>
        public int ProjectID { get; set; }

        /// <summary>
        /// 项目分组
        /// </summary>
        public string ProjectGroup { get; set; }

        /// <summary>
        /// 摇号结果列表
        /// </summary>
        public List<ShakingNumberResultEntity> ShakingNumberList { get; set; }
    }
}
