using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Enum
{
    public enum InterfaceResultEnum
    {
        [Description("操作成功")]
        Success = 0,
        [Description("操作失败")]
        Error = 1,
        [Description("参数错误")]
        ParamError = 2,
        [Description("未知异常")]
        UnknowError = 99,

        // 从100往后开始，100以内系统保留

        [Description("无法获取应用信息，请检查AppId和AppSecret是否正确")]
        AppError = 100,
    }
}
