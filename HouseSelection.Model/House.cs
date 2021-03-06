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
    
    public partial class House
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public House()
        {
            this.HouseSelectionRecord = new HashSet<HouseSelectionRecord>();
        }
    
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public int SerialNumber { get; set; }
        public int GroupID { get; set; }
        public string Block { get; set; }
        public int Building { get; set; }
        public int Unit { get; set; }
        public string RoomNumber { get; set; }
        public int RoomTypeID { get; set; }
        public string Toward { get; set; }
        public string RoomTypeCode { get; set; }
        public decimal EstimateBuiltUpArea { get; set; }
        public decimal EstimateLivingArea { get; set; }
        public decimal AreaUnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
        public int HouseEstateID { get; set; }
        public Nullable<int> SubscriberID { get; set; }
    
        public virtual HouseGroup HouseGroup { get; set; }
        public virtual HouseEstate HouseEstate { get; set; }
        public virtual Project Project { get; set; }
        public virtual RoomType RoomType { get; set; }
        public virtual Subscriber Subscriber { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HouseSelectionRecord> HouseSelectionRecord { get; set; }
    }
}
