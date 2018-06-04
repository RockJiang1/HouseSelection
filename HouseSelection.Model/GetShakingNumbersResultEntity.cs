using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Model
{
    public class GetShakingNumbersResultEntity : BaseListResultEntity
    {
        public List<GetShakingNumberResultEntity> ShakingNumberResultList { get; set; }
    }
}
