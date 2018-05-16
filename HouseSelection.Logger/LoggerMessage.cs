using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Logger
{
    /// <summary>
    /// 日志消息类
    /// </summary>
    public class LoggerMessage
    {
        public const string MESSAGE_FORMAT = "Level:{0} Class:{1} Function:{2} Message:{3}";

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 类名称
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string FunctionName { get; set; }

        /// <summary>
        /// 日志级别
        /// </summary>
        public LogLevel Level { get; set; }

        /// <summary>
        /// 重写ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format(MESSAGE_FORMAT, this.Level.ToString(), this.ClassName, this.FunctionName, this.Message);
        }
    }

    public enum LogLevel
    {
        INFO = 0,
        DEBUG = 1,
        WARING = 2,
        EXCEPTION = 3
    }
}
