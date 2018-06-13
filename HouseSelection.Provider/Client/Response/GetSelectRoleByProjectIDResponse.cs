using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.Model;
using HouseSelection.Provider.Client.Request;

namespace HouseSelection.Provider.Client.Response
{
    public class GetSelectRoleByProjectIDResponse : BaseResultEntity
    {
        public List<ProjectGroupAndRoomTypeRoleTemp> ProjectGroupAndRoomTypeRoleList { get; set; }

        public List<FamilyNumberAndRoomTypeRoleTemp> FamilyNumberAndRoomTypeRoleList { get; set; }

        public List<ProjectGroupAndHouseGroupRoleTemp> ProjectGroupAndHouseGroupRoleList { get; set; }

        //public int RecordCount { get; set; }
    }
}




