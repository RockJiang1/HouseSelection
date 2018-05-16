using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.NetworkHelper
{
    /// <summary>
    /// 请求参数属性
    /// </summary>
    public class RequestPropertyAttribute : Attribute
    {
        /// <summary>
        /// 参数名称
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// 是否需要JSON序列化
        /// </summary>
        public bool JsonSerializable { get; set; }

        /// <summary>
        /// 如果为空时进行排除，默认为false
        /// </summary>
        public bool ExcludeIfNull { get; set; }

        /// <summary>
        /// 是否不包含SET访问器
        /// </summary>
        public bool NoSet { get; set; }
    }
}
