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
    
    public partial class BackEndAccountLoginRecord
    {
        public int ID { get; set; }
        public int BackEndAccountID { get; set; }
        public System.DateTime LoginTime { get; set; }
        public string LoginIP { get; set; }
    
        public virtual BackEndAccount BackEndAccount { get; set; }
    }
}
