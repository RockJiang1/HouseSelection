using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Model
{
    public class AddSelectRoleRequestEntity
    {
        /// <summary>
        /// 项目ID
        /// </summary>
        public int ProjectID { get; set; }

        /// <summary>
        /// 项目分组和户型关系规则
        /// </summary>
        public List<ProjectGroupAndRoomTypeRole> ProjectGroupAndRoomTypeRoleList { get; set; }

        /// <summary>
        /// 家庭人数和户型规则
        /// </summary>
        public List<FamilyNumberAndRoomTypeRole> FamilyNumberAndRoomTypeRoleList { get; set; }

        /// <summary>
        /// 项目分组和房源分组规则
        /// </summary>
        public List<ProjectGroupAndHouseGroupRole> ProjectGroupAndHouseGroupRoleList { get; set; }
    }

    public class ProjectGroupAndRoomTypeRole
    {
        public int ProjectGroupID { get; set; }
        public int RoomTypeID { get; set; }
    }

    public class FamilyNumberAndRoomTypeRole
    {
        public int FamilyNumber { get; set; }
        public int RoomTypeID { get; set; }
    }

    public class ProjectGroupAndHouseGroupRole
    {
        public int ProjectGroupID { get; set; }
        public int HouseGroupID { get; set; }
    }
}
