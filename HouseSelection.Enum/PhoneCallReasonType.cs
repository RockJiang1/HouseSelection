using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Enum
{
    public enum PhoneCallReasonType
    {
        
        [Description("有效电话")]
        Valid = 1,

        [Description("关机")]
        PhoneOff = 2,

        [Description("不在服务区")]
        NotInServiceArea = 3,

        [Description("停机")]
        PhoneDown = 4,

        [Description("无人接听")]
        NoAnswered = 5,

        [Description("挂断")]
        HangUp = 6,

        [Description("空号")]
        PhoneEmpty = 7,

        [Description("暂时不方便稍后再拨")]
        Inconvenient = 8,

        [Description("非本人")]
        NotOneself = 9

    }
}
