//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Utac.DataAccessLogic.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class View_Tbl_UserTransaction
    {
        public System.Guid Guid { get; set; }
        public Nullable<System.Guid> User_Guid { get; set; }
        public string Type { get; set; }
        public string DataJson { get; set; }
        public Nullable<System.DateTime> Create_Date { get; set; }
        public Nullable<long> rn { get; set; }
    }
}
