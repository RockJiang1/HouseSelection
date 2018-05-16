using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using log4net;

namespace HouseSelection.Logger
{
    public static class Logger
    {
        /* 静态成员 */
        private static readonly ILog logger = LogManager.GetLogger(typeof(log4net.Repository.Hierarchy.Logger));
        private const string LOGFMT_PATH_DESC = "{0}\t{1}.{2}";
        private const string LOGFMT_EXCPT_PATH_DESC = "{0}\t{1}.{2}\r\n==EXCEPTION==\r\n{3}";
        private static EventHandler<LoggerEventArgs> onLog;
        private static IList<LoggerMessage> messagePool;
        private static int messagePoolSize;

        static Logger()
        {
            //创建消息池
            messagePool = new List<LoggerMessage>();

            //载入缓冲池大小
            ReloadPoolSize();

            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// 重新载入缓冲池大小
        /// </summary>
        public static void ReloadPoolSize()
        {
            //从配置读取LOG池的大小
            int logPoolSize = 1000;
            logPoolSize = int.TryParse(ConfigurationManager.AppSettings["logPoolSize"], out logPoolSize) ? logPoolSize : 1000;
            MessagePoolSize = logPoolSize;
        }

        /// <summary>
        /// 获取或设置一个值，表示消息池的最大容量
        /// </summary>
        public static int MessagePoolSize
        {
            get { return messagePoolSize; }
            set
            {
                messagePoolSize = value;

                if (messagePool == null)
                {
                    return;
                }

                //确定起始读取的索引
                int startIndex = messagePool.Count > messagePoolSize ? messagePool.Count - messagePoolSize : 0;
                //确定结束读取的索引
                int endIndex = startIndex + messagePoolSize > messagePool.Count ? messagePool.Count : startIndex + messagePoolSize;

                //获取区间
                var buffer = messagePool.Skip<LoggerMessage>(startIndex).Take<LoggerMessage>(endIndex).ToArray();

                //实例化新的实例
                messagePool = new List<LoggerMessage>(buffer);
            }
        }

        /// <summary>
        /// 当记录日志时触发
        /// </summary>
        public static event EventHandler<LoggerEventArgs> OnLog
        {
            add
            {
                if (onLog == null)
                {
                    onLog = new EventHandler<LoggerEventArgs>(value);
                }
                else
                {
                    onLog += value;
                }
            }
            remove
            {
                if (onLog != null)
                {
                    onLog -= value;
                }
            }
        }

        /// <summary>
        /// 获取一个值，表示日志的记录者
        /// </summary>
        public static ILog Log
        {
            get
            {
                return logger;
            }
        }

        /// <summary>
        /// 返回日志缓冲池
        /// </summary>
        public static IList<LoggerMessage> MessagePool
        {
            get
            {
                return messagePool;
            }
        }

        /// <summary>
        /// 保存日志信息
        /// </summary>
        /// <param name="message"></param>
        private static void SaveLog(LoggerMessage message)
        {
            //保存到日志容器
            messagePool.Add(message);

            if (messagePool.Count > messagePoolSize)
            {
                int overfllowCount = messagePool.Count - messagePoolSize;

                for (int i = 0; i < overfllowCount; i++)
                {
                    var msg = messagePool[i];

                    //如果数量超过，那么移除最早的日志
                    messagePool.RemoveAt(i);

                    //如果被移除则通知外部
                    if (onLog != null)
                    {
                        DoEvent(onLog, new LoggerEventArgs() { Function = LoggerFunction.Remove, Message = msg });
                    }
                }
            }

            //发送新增事件
            DoEvent(onLog, new LoggerEventArgs() { Function = LoggerFunction.Add, Message = message });
        }

        /// <summary>
        /// 发送日志事件
        /// </summary>
        /// <param name="dlg"></param>
        /// <param name="e"></param>
        private static void DoEvent(Delegate dlg, EventArgs e)
        {
            try
            {
                //获取该Dlg所拥有的窗体
                var ownerControl = EventHelper.GetDelegateOwner(dlg);

                if (ownerControl != null && !ownerControl.IsDisposed)
                {
                    ownerControl.Invoke(dlg, Log, e);
                }
            }
            catch
            {

            }
        }

        public static void LogInfo(string layer, string className, string functionName)
        {
            Log.InfoFormat(LOGFMT_PATH_DESC, layer, className, functionName);

            LoggerMessage message = new LoggerMessage()
            {
                Message = layer,
                ClassName = className,
                FunctionName = functionName,
                Level = LogLevel.DEBUG
            };
            SaveLog(message);
        }

        public static void LogDebug(string layer, string className, string functionName)
        {
            Log.DebugFormat(LOGFMT_PATH_DESC, layer, className, functionName);

            LoggerMessage message = new LoggerMessage()
            {
                Message = layer,
                ClassName = className,
                FunctionName = functionName,
                Level = LogLevel.INFO
            };
            SaveLog(message);
        }

        public static void LogWarning(string layer, string className, string functionName)
        {
            Log.WarnFormat(LOGFMT_PATH_DESC, layer, className, functionName);

            LoggerMessage message = new LoggerMessage()
            {
                Message = layer,
                ClassName = className,
                FunctionName = functionName,
                Level = LogLevel.WARING
            };
            SaveLog(message);
        }

        public static void LogError(string layer, string className, string functionName, string desc)
        {
            Log.ErrorFormat(LOGFMT_PATH_DESC, layer, className, functionName, desc);

            LoggerMessage message = new LoggerMessage()
            {
                Message = layer,
                ClassName = className,
                FunctionName = functionName,
                Level = LogLevel.EXCEPTION
            };
            SaveLog(message);
        }

        public static void LogException(string layer, string className, string functionName, Exception ex)
        {
            Log.FatalFormat(LOGFMT_EXCPT_PATH_DESC, layer + Environment.NewLine + ex.ToString(), className, functionName, ex);

            LoggerMessage message = new LoggerMessage()
            {
                Message = layer,
                ClassName = className,
                FunctionName = functionName,
                Level = LogLevel.EXCEPTION
            };
            SaveLog(message);
        }
    }
}
