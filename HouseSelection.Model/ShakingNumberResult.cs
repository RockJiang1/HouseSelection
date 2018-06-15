//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HouseSelection.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ShakingNumberResult
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ShakingNumberResult()
        {
            this.HouseSelectPeriod = new HashSet<HouseSelectPeriod>();
            this.TelephoneNoticeRecord = new HashSet<TelephoneNoticeRecord>();
        }
    
        public int ID { get; set; }
        public int ProjectGroupID { get; set; }
        public int SubscriberProjectMappingID { get; set; }
        public int ShakingNumberSequance { get; set; }
        public string ShakingNumber { get; set; }
        public int NoticeTime { get; set; }
        public bool IsError { get; set; }
        public bool IsContacted { get; set; }
        public bool IsCallBack { get; set; }
        public bool IsMessageSend { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
        public bool IsAuthorized { get; set; }
        public int SelectHouseSequance { get; set; }
        public bool IsAgent { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HouseSelectPeriod> HouseSelectPeriod { get; set; }
        public virtual ProjectGroup ProjectGroup { get; set; }
        public virtual SubscriberProjectMapping SubscriberProjectMapping { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TelephoneNoticeRecord> TelephoneNoticeRecord { get; set; }
    }
}
