using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseSelection.Model
{
    public class GetSubscriberByHouseIDResultEntity : BaseResultEntity
    {
        /// <summary>
        /// 认购人ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdentityNumber { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// 联系地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// 婚姻情况
        /// </summary>
        public string MaritalStatus { get; set; }

        /// <summary>
        /// 户籍所在区县
        /// </summary>
        public string ResidenceArea { get; set; }

        /// <summary>
        /// 工作所在区县
        /// </summary>
        public string WorkArea { get; set; }

        /// <summary>
        /// 认购时间
        /// </summary>
        public DateTime SelectTime { get; set; }
    }
}
