using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.DAL;
using HouseSelection.Model;

namespace HouseSelection.BLL
{
    public class HouseBLL : BaseBLL<House>
    {
        private HouseDAL _houseDAL = new HouseDAL();
        public override void SetDAL()
        {
            _dal = new HouseDAL();
        }

        public List<House> GetValidHouses(int ShakingNumberID, int HouseEstateID, int Building)
        {
            return _houseDAL.GetValidHouses(ShakingNumberID, HouseEstateID, Building);
        }

        public bool ValidHouseSelection(int ShakingNumberID, int HouseID)
        {
            return _houseDAL.ValidHouseSelection(ShakingNumberID, HouseID);
        }
    }
}
