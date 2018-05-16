using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Logger
{
    /// <summary>
    /// 日志事件参数
    /// </summary>
    public class LoggerEventArgs : EventArgs
    {
        /// <summary>
        /// 获取或设置一个值，表示日志的消息
        /// </summary>
        public LoggerMessage Message { get; set; }

        /// <summary>
        /// 日志行为
        /// </summary>
        public LoggerFunction Function { get; set; }
    }

    /// <summary>
    /// 日志行为
    /// </summary>
    public enum LoggerFunction
    {
        Add = 0,
        Remove = 1
    }
}
