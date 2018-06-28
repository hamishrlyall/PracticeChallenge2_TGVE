//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TGVE.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TourEvent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TourEvent()
        {
            this.Bookings = new HashSet<Booking>();
        }
    
        public int EventID { get; set; }
        public System.DateTime EventDate { get; set; }
        public decimal Fee { get; set; }
        public string TourName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual Tour Tour { get; set; }
    }
}
