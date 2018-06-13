using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.Model;

namespace HouseSelection.Provider.Client.Response
{
    public class GetProjectGroupResponse : BaseListResultEntity
    {
        public GetProjectGroupResponse()
        {
            this.ProjectGroupList = new List<GetProjectGroupResponseTemp>();
        }
        /// <summary>
        /// 房源ID
        /// </summary>
        public List<GetProjectGroupResponseTemp> ProjectGroupList { get; set; }

        //public int RecordCount { get; set; }
    }
    public class GetProjectGroupResponseTemp
    {
        public GetProjectGroupResponseTemp()
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
        public int ProjectID { get; set; }
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
        public int ProjectGroupID { get; set; }
        /// <summary>
        /// 账号名称
        /// </summary>
        public string ProjectGroupName { get; set; }
        /// <summary>
        /// 操作
        /// </summary>
        public string Operate { get; set; }
        /// <summary>
        /// 操作
        /// </summary>
        public string Operate1 { get; set; }
        /// <summary>
        /// 操作
        /// </summary>
        public string Operate2 { get; set; }
        /// <summary>
        /// 操作
        /// </summary>
        public string Operate3 { get; set; }
    }
}



