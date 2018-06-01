using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.NetworkHelper;

namespace HouseSelection.Provider.Client.Request
{
    public class ImportSubscriberRequest : GeneralRequest
    {
        protected override string APIAddress
        {
            get { return "/api/GetSubscribers"; }
        }
        public ImportSubscriberRequest()
        {
            this.ShakingNumberList = new List<ShakingNumberResultEntitytemp>();
        }

        /// <summary>
        /// 房源ID
        /// </summary>
        public int PrijectID { get; set; }
        /// <summary>
        /// 房源ID
        /// </summary>
        public string PrijectGroup { get; set; }
        /// <summary>
        /// 房源ID
        /// </summary>
        [RequestProperty(JsonSerializable = true)]
        public List<ShakingNumberResultEntitytemp> ShakingNumberList { get; set; }
    }

    public class ShakingNumberResultEntitytemp
    {
        public ShakingNumberResultEntitytemp()
        {
            this.SubscriberFamilyMemberEntity = new List<SubscriberFamilyMemberEntitytemp>();
            this.Subscriber = new SubscriberEntitytemp();
        }
        /// <summary>
        /// erp方菜品id
        /// </summary>
        public int ShakingNumberSequance { get; set; }
        public string ShakingNumber { get; set; }
        public SubscriberEntitytemp Subscriber { get; set; }
        /// <summary>
        /// 菜品sku 参考sku
        /// </summary>
        public List<SubscriberFamilyMemberEntitytemp> SubscriberFamilyMemberEntity { get; set; }
    }

    /// <summary>
    /// sku说明
    /// </summary>
    public class SubscriberEntitytemp
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdentityNumber { get; set; }
        /// <summary>
        /// 电话号码
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
    }

    public class SubscriberFamilyMemberEntitytemp
    {
        /// <summary>
        /// 工作所在区县
        /// </summary>
        public string SubscriberIdentityNumber { get; set; }
        /// <summary>
        /// 工作所在区县
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 工作所在区县
        /// </summary>
        public string IdentityNumber { get; set; }
        /// <summary>
        /// 工作所在区县
        /// </summary>
        public string Relationship { get; set; }
        /// <summary>
        /// 工作所在区县
        /// </summary>
        public string Area { get; set; }
    }

    public class SubscriberTable
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int No { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdentityNumber { get; set; }
        /// <summary>
        /// 摇号编号
        /// </summary>
        public string ShakingNumber { get; set; }
        /// <summary>
        /// 电话号码
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
        /// 家庭信息
        /// </summary>
        public string SubscriberFamilyMemberEntity { get; set; }
    }
}