using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Model
{
    public class GetSubscriberResultEntity : BaseListResultEntity
    {
        public List<SubscriberEntity> SubscriberList { get; set; }
    }
}
