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
    
    public partial class JOB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JOB()
        {
            this.APPLICATIONs = new HashSet<APPLICATION>();
        }
    
        public int JOB_ID { get; set; }
        public string SITE_ID { get; set; }
        public string JOB_TITLE { get; set; }
        public string JOB_DESC { get; set; }
        public string CONTACT_EMAIL { get; set; }
        public string CONTACT_PHONE { get; set; }
        public decimal JOB_SALARY { get; set; }
        public System.DateTime START_DATE { get; set; }
        public System.DateTime CLOSE_DATE { get; set; }
        public string APPLICATION_METHOD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APPLICATION> APPLICATIONs { get; set; }
        public virtual SITE SITE { get; set; }
    }
}
