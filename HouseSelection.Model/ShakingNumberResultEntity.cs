using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Model
{
    public class ShakingNumberResultEntity
    {
        /// <summary>
        /// 摇号顺序号
        /// </summary>
        public int ShakingNumberSequance { get; set; }

        /// <summary>
        /// 摇号编号
        /// </summary>
        public string ShakingNumber { get; set; }

        /// <summary>
        /// 认购人
        /// </summary>
        public SubscriberEntity Subscriber { get; set; }

        /// <summary>
        /// 认购人家庭成员
        /// </summary>
        public List<SubscriberFamilyMemberEntity> FamilyMemberList { get; set; }
    }
}
