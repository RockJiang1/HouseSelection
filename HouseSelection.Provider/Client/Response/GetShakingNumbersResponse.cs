using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.Model;

namespace HouseSelection.Provider.Client.Response
{
    public class GetShakingNumbersResponse : BaseResultEntity
    {
        public GetShakingNumbersResponse()
        {
            this.ShakingNumberResultList = new List<GetShakingNumberResultEntityTemp>();
        }
        /// <summary>
        /// 房源ID
        /// </summary>
        public List<GetShakingNumberResultEntityTemp> ShakingNumberResultList { get; set; }

        //public int RecordCount { get; set; }
    }

    public class GetShakingNumberResultEntityTemp
    {
        public GetShakingNumberResultEntityTemp()
        {
            this.Subscriber = new SubscriberEntityTemp();
        }
        /// <summary>
        /// 序号
        /// </summary>
        public int ShakingNumberSequance { get; set; }
        /// <summary>
        /// 前台账号ID
        /// </summary>
        public int SelectHouseSequance { get; set; }
        /// <summary>
        /// 所属项目编号
        /// </summary>
        public string ShakingNumber { get; set; }

        public SubscriberEntityTemp Subscriber { get; set; }
    }

    public class GetShakingNumberSource
    {
        /// <summary>
        /// 序号
        /// </summary>
        public string ShakingNumber { get; set; }
        /// <summary>
        /// 前台账号ID
        /// </summary>
        public int ShakingNumberSequance { get; set; }
        /// <summary>
        /// 所属项目编号
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 所属项目名称
        /// </summary>
        public string IdentityNumber { get; set; }

        /// <summary>
        /// 账号名称
        /// </summary>
        public string Telephone { get; set; }
        
    }
}




