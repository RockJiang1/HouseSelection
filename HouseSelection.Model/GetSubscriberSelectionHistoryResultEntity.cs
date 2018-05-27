using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Model
{
    public class GetSubscriberSelectionHistoryResultEntity : BaseResultEntity
    {
        public List<SubscriberSelectionEntity> SelectionList { get; set; }
    }
}
