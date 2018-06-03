using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.Model;

namespace HouseSelection.Provider.Client.Response
{
    public class GetFrontEndAccountResponse: BaseResultEntity
    {
        public GetFrontEndAccountResponse()
        {
            this.AccountList = new List<FrontEndAccountEntityTemp>();
        }
        /// <summary>
        /// 房源ID
        /// </summary>
        public List<FrontEndAccountEntityTemp> AccountList { get; set; }

        //public int recordCount { get; set; }
    }
    public class FrontEndAccountEntityTemp
    {
        public FrontEndAccountEntityTemp()
        {
            this.No = 0;
            this.Operate = "";
        }
        /// <summary>
        /// 序号
        /// </summary>
        public int No { get; set; }
        /// <summary>
        /// 前台账号ID
        /// </summary>
        public int AccountID { get; set; }
        /// <summary>
        /// 所属项目编号
        /// </summary>
        public string ProjectNumber { get; set; }

        /// <summary>
        /// 所属项目名称
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// 账号名称
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 操作
        /// </summary>
        public string Operate { get; set; }
    }
}


