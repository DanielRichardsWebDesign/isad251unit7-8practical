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
    
    public partial class STUDENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STUDENT()
        {
            this.APPLICATIONs = new HashSet<APPLICATION>();
        }
    
        public string SRN { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string STUDENT_USERNAME { get; set; }
        public string STUDENT_PASS { get; set; }
        public string PROGRAMME_CODE { get; set; }
        public System.DateTime DOB { get; set; }
        public string HOUSE_NUMBER_TERM { get; set; }
        public string STREET_TERM { get; set; }
        public string POSTCODE_TERM { get; set; }
        public string HOUSE_NUMBER_HOME { get; set; }
        public string STREET_HOME { get; set; }
        public string POSTCODE_HOME { get; set; }
        public string MOBILE_NUMBER { get; set; }
        public string LANDLINE_NUMBER { get; set; }
        public string EMAIL_ADDRESS { get; set; }
        public string PLACEMENT_NOTES { get; set; }
        public string CV_SUBMITTED { get; set; }
        public string CV_APPROVED { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APPLICATION> APPLICATIONs { get; set; }
        public virtual PROGRAMME PROGRAMME { get; set; }
    }
}
