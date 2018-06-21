using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Model
{
    public class DialedInfo
    {
        public int ShakingNumberResultId { get; set; }


        public int ShakingNumberSequance { get; set; }

        public int SelectHouseSequence { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string IdentityID { get; set; }

        public bool IsUndialed { get; set; }

        public bool IsContacted { get; set; }

        public bool IsCallBack { get; set; }

        public bool IsMessageSend { get; set; }

        public int CallTimes { get; set; }

        public string LastCallTime { get; set; }

        public string BeginTime { get; set; }

        public string EndTime { get; set; }

        public int ResultType { get; set; }
    }
}
