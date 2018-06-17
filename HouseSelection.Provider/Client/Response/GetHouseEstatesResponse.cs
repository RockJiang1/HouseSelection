using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.Model;

namespace HouseSelection.Provider.Client.Response
{
    public class GetHouseEstatesResponse : BaseListResultEntity
    {
        public GetHouseEstatesResponse()
        {
            this.HouseEstateList = new List<HouseEstateEntityTemp>();
        }
        /// <summary>
        /// 房源ID
        /// </summary>
        public List<HouseEstateEntityTemp> HouseEstateList { get; set; }

        //public int RecordCount { get; set; }
    }

    public class HouseEstateEntityTemp
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int HouseEstateID { get; set; }
        /// <summary>
        /// 前台账号ID
        /// </summary>
        public string ProjectNumber { get; set; }
        /// <summary>
        /// 所属项目编号
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// 所属项目名称
        /// </summary>
        public string HouseEstateName { get; set; }
    }

    public class HouseEstateSource
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int HouseEstateID { get; set; }
        /// <summary>
        /// 前台账号ID
        /// </summary>
        public string ProjectNumber { get; set; }
        /// <summary>
        /// 所属项目编号
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// 所属项目名称
        /// </summary>
        public string HouseEstateName { get; set; }
        /// <summary>
        /// 所属项目名称
        /// </summary>
        public string Operate { get; set; }
    }
}



