using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.Model;

namespace HouseSelection.DAL
{
    public class HouseDAL : BaseDAL<House>
    {
        public List<House> GetValidHouses(int ShakingNumberID, int HouseEstateID, int Building)
        {
            using (HouseSelectionDBEntities DB  = new HouseSelectionDBEntities())
            {
                var _shaking = DB.ShakingNumberResult.FirstOrDefault(x => x.ID == ShakingNumberID);
                return (from H in DB.House
                                  where H.HouseEstateID == HouseEstateID
                                  && H.Building == Building
                                  && H.SubscriberID != null
                                  && DB.RoleProjectGroupAndHouseGroup.Any(x => x.HouseGroupID == H.GroupID && x.ProjectGroupID == _shaking.ProjectGroupID)
                                  && DB.RoleFamilyNumberAndRoomType.Any(x => x.RoomTypeID == H.RoomTypeID && x.FamilyNumber == _shaking.SubscriberProjectMapping.Subscriber.FamilyMemberNumber)
                                  && DB.RoleProjectGroupAndRoomType.Any(x => x.RoomTypeID == H.RoomTypeID && x.ProjectGroupID == _shaking.ProjectGroupID)).ToList();

            }
        }
    }
}
