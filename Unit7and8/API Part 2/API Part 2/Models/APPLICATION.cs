//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API_Part_2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class APPLICATION
    {
        public string APPLICATION_ID { get; set; }
        public Nullable<int> JOB_ID { get; set; }
        public string SRN { get; set; }
        public string APP_STATUS { get; set; }
        public System.DateTime DATE_SUBMITTED { get; set; }
    
        public virtual JOB JOB { get; set; }
        public virtual STUDENT STUDENT { get; set; }
    }
}
