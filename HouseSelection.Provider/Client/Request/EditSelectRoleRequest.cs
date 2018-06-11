using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.NetworkHelper;

namespace HouseSelection.Provider.Client.Request
{
    public class EditSelectRoleRequest : GeneralRequest
    {
        protected override string APIAddress
        {
            get { return "/api/EditSelectRole"; }
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
}




