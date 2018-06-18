 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.NetworkHelper;
using HouseSelection.Model;

namespace HouseSelection.Provider.Client.Request
{
    public class ImportHouseInfoRequest : GeneralRequest
    {
        protected override string APIAddress
        {
            get { return "/api/ImportHouseInfo"; }
        }

        public ImportHouseInfoRequest()
        {
            this.HouseList = new List<HouseInfoTable>();
        }

        /// <summary>
        /// 房源ID
        /// </summary>
        public int ProjectID { get; set; }
        /// <summary>
        /// 房源ID
        /// </summary>
        public string HouseEstate { get; set; }
        /// <summary>
        /// 房源ID
        /// </summary>
        //[RequestProperty(JsonSerializable = true)]
        public List<HouseInfoTable> HouseList { get; set; }
    }

    public class HouseInfoTable
    {
        /// <summary>
        /// 房源序号
        /// </summary>
        public int SerialNumber { get; set; }
        /// <summary>
        /// 组别
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
        /// 居室
        /// </summary>
        public string RoomType { get; set; }
        /// <summary>
        /// 朝向
        /// </summary>
        public string Toward { get; set; }
        /// <summary>
        /// 户型代码
        /// </summary>
        public string RoomCode { get; set; }
        /// <summary>
        /// 预测建筑面积
        /// </summary>
        public decimal EstimateBuiltUpArea { get; set; }
        /// <summary>
        /// 预测套内面积
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
    }
}



    
