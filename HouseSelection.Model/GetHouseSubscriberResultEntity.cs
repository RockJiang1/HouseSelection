using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Model
{
    public class GetHouseSubscriberResultEntity : BaseResultEntity
    {
        public SubscriberEntity Subscriber { get; set; }
    }
}
