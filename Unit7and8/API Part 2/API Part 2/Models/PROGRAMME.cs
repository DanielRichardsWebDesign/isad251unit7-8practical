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
    
    public partial class PROGRAMME
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROGRAMME()
        {
            this.STUDENTs = new HashSet<STUDENT>();
        }
    
        public string PROGRAMME_CODE { get; set; }
        public string PROGRAMME_NAME { get; set; }
        public string PROGRAMME_LEADER { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STUDENT> STUDENTs { get; set; }
    }
}
