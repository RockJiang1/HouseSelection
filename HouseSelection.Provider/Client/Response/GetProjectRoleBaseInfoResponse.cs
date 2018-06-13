using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.Model;

namespace HouseSelection.Provider.Client.Response
{
    public class GetProjectRoleBaseInfoResponse : BaseResultEntity
    {
        public GetProjectRoleBaseInfoResponse()
        {
            this.ProjectGroupList = new List<ProjectGroupSingleEntityTemp>();
            this.RoomTypeList = new List<RoomTypeEntityTemp>();
            this.FamilyNumber = new List<int>();
            this.HouseGroupList = new List<HouseGroupEntityTemp>();

        }
        /// <summary>
        /// 房源ID
        /// </summary>
        public List<ProjectGroupSingleEntityTemp> ProjectGroupList { get; set; }
        public List<RoomTypeEntityTemp> RoomTypeList { get; set; }
        public List<int> FamilyNumber { get; set; }
        public List<HouseGroupEntityTemp> HouseGroupList { get; set; }
    }
    public class ProjectGroupSingleEntityTemp
    {
        /// <summary>
        /// 项目分组ID
        /// </summary>
        public int ProjectGroupID { get; set; }

        /// <summary>
        /// 项目分组名称
        /// </summary>

        public string ProjectGroupName { get; set; }
    }

    public class RoomTypeEntityTemp
    {
        public int RoomTypeID { get; set; }
        public string RoomTypeName { get; set; }
    }
    public class HouseGroupEntityTemp
    {
        public int HouseGroupID { get; set; }
        public string HouseGroupName { get; set; }
    }
}



