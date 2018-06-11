using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.Model;

namespace HouseSelection.Provider.Client.Response
{
    public class GetSubscriberByHouseIDResponse : BaseResultEntity
    {
        public int ID { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 分组
        /// </summary>
        public string IdentityNumber { get; set; }

        /// <summary>
        /// 地块
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// 楼号
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 单元
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// 房号
        /// </summary>
        public string MaritalStatus { get; set; }

        /// <summary>
        /// 朝向
        /// </summary>
        public string ResidenceArea { get; set; }

        /// <summary>
        /// 居室
        /// </summary>
        public string WorkArea { get; set; }

        /// <summary>
        /// 预计建筑面积
        /// </summary>
        public DateTime SelectTime { get; set; }
    }
}



