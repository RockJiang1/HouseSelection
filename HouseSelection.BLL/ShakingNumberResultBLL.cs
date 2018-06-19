using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.DAL;
using HouseSelection.Model;

namespace HouseSelection.BLL
{
    public class ShakingNumberResultBLL : BaseBLL<ShakingNumberResult>
    {
        private ShakingNumberResultDAL _shakingResultDAL = new ShakingNumberResultDAL();
        public override void SetDAL()
        {
            _dal = new ShakingNumberResultDAL();
        }

        public List<DialedInfo> GetSubscriberDialingStatus(int GroupID, int StartSeq, int EndSeq)
        {
            return _shakingResultDAL.GetSubscriberDialingStatus(GroupID, StartSeq, EndSeq);
        }
    }
}
