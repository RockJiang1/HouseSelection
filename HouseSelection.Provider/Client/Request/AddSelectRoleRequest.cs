using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.NetworkHelper;

namespace HouseSelection.Provider.Client.Request
{
    public class AddSelectRoleRequest : GeneralRequest
    {
        protected override string APIAddress
        {
            get { return "/api/AddSelectRole"; }
        }

        public override PostRequestContentType ContentType
        {
            get { return PostRequestContentType.Json; }
        }

        /// <summary>
        /// ERP门店ID
        /// </summary>
        public int ProjectID { get; set; }

        public List<ProjectGroupAndRoomTypeRoleTemp> ProjectGroupAndRoomTypeRoleList { get; set; }

        public List<FamilyNumberAndRoomTypeRoleTemp> FamilyNumberAndRoomTypeRoleList { get; set; }

        public List<ProjectGroupAndHouseGroupRoleTemp> ProjectGroupAndHouseGroupRoleList { get; set; }
    }

    public class ProjectGroupAndRoomTypeRoleTemp
    {
        public int ProjectGroupID { get; set; }
        /// <summary>
        /// 前台账号ID
        /// </summary>
        public int RoomTypeID { get; set; }
    }

    public class FamilyNumberAndRoomTypeRoleTemp
    {
        public int FamilyNumber { get; set; }
        /// <summary>
        /// 前台账号ID
        /// </summary>
        public int RoomTypeID { get; set; }
    }

    public class ProjectGroupAndHouseGroupRoleTemp
    {
        public int ProjectGroupID { get; set; }
        /// <summary>
        /// 前台账号ID
        /// </summary>
        public int HouseGroupID { get; set; }
    }
}



