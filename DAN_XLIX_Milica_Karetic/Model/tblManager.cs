//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAN_XLIX_Milica_Karetic.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblManager
    {
        public int ManagerID { get; set; }
        public int Floor { get; set; }
        public int Experience { get; set; }
        public int QualificationsLevel { get; set; }
        public int UserID { get; set; }
    
        public virtual tblUser tblUser { get; set; }
    }
}