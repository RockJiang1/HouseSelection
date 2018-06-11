using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.Model;
using HouseSelection.DAL;

namespace HouseSelection.BLL
{
    public class HouseSelectionRecordBLL : BaseBLL<HouseSelectionRecord>
    {
        private HouseSelectionRecordDAL _selectDAL = new HouseSelectionRecordDAL();
        public override void SetDAL()
        {
            _dal = new HouseSelectionRecordDAL();
        }

        public List<SubscriberSelectionEntity> GetSubscriberSelectionRecord(int SubscriberID)
        {
            return _selectDAL.GetSubscriberSelectionRecord(SubscriberID);
        }
    }
}
