using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Model
{
    public class GetProjectRoleBaseInfoResultEntity : BaseResultEntity
    {
        /// <summary>
        /// 项目分组列表
        /// </summary>
        public List<ProjectGroupSingleEntity> ProjectGroupList { get; set; }

        /// <summary>
        /// 户型列表
        /// </summary>
        public List<RoomTypeEntity> RoomTypeList { get; set; } 

        /// <summary>
        /// 家庭人数列表
        /// </summary>
        public List<int> FamilyNumber { get; set; }

        /// <summary>
        /// 房源分组列表
        /// </summary>
        public List<HouseGroupEntity> HouseGroupList { get; set; }
    }
}
