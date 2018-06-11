using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.Model;

namespace HouseSelection.Provider.Client.Response
{
    public class GetHousesResponse : BaseResultEntity
    {
        public GetHousesResponse()
        {
            this.HouseList = new List<HouseEntityTemp>();
        }
        /// <summary>
        /// 房源ID
        /// </summary>
        public List<HouseEntityTemp> HouseList { get; set; }

        //public int RecordCount { get; set; }
    }

    public class HouseEntityTemp
    {
        /// <summary>
        /// 房源ID
        /// </summary>
        public int HouseID { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public int SerialNumber { get; set; }

        /// <summary>
        /// 分组
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// 地块
        /// </summary>
        public string Block { get; set; }

        /// <summary>
        /// 楼号
        /// </summary>
        public int Building { get; set; }

        /// <summary>
        /// 单元
        /// </summary>
        public int Unit { get; set; }

        /// <summary>
        /// 房号
        /// </summary>
        public string RoomNumber { get; set; }

        /// <summary>
        /// 朝向
        /// </summary>
        public string Toward { get; set; }

        /// <summary>
        /// 居室
        /// </summary>
        public string RoomType { get; set; }

        /// <summary>
        /// 预计建筑面积
        /// </summary>
        public decimal EstimateBuiltUpArea { get; set; }

        /// <summary>
        /// 预计套内面积
        /// </summary>
        public decimal EstimateLivingArea { get; set; }

        /// <summary>
        /// 建筑单价
        /// </summary>
        public decimal AreaUnitPrice { get; set; }

        /// <summary>
        /// 总价
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// 认购人ID
        /// </summary>
        public int? SubscriberID { get; set; }

        /// <summary>
        /// 认购人姓名
        /// </summary>
        public string SubscriberName { get; set; }
        /// <summary>
        /// 认购人状态
        /// </summary>
        public string SubscriberStatus { get; set; }
        /// <summary>
        /// 操作
        /// </summary>
        public string Operate { get; set; }
    }
}



