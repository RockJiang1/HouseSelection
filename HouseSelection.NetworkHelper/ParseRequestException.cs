using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.NetworkHelper
{
    public class ParseRequestException : Exception
    {
        /// <summary>
        /// 初始化异常
        /// </summary>
        /// <param name="propertyName">出错字段的名称</param>
        public ParseRequestException(string propertyName)
            : base()
        {
            this.PropertyName = propertyName;
        }

        /// <summary>
        /// 获取一个值，表示出错属性的名称
        /// </summary>
        public string PropertyName { get; private set; }
    }
}
