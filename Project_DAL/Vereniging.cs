//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vereniging
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vereniging()
        {
            this.GebruikerVereniging = new HashSet<GebruikerVereniging>();
            this.VerenigingCategorie = new HashSet<VerenigingCategorie>();
            this.VerenigingContactpersoon = new HashSet<VerenigingContactpersoon>();
            this.VerenigingEvent = new HashSet<VerenigingEvent>();
        }
    
        public int id { get; set; }
        public string naam { get; set; }
        public Nullable<int> telefoonnr { get; set; }
        public string beschrijving { get; set; }
        public string straat { get; set; }
        public string huisnr { get; set; }
        public string gemeente { get; set; }
        public string postcode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GebruikerVereniging> GebruikerVereniging { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VerenigingCategorie> VerenigingCategorie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VerenigingContactpersoon> VerenigingContactpersoon { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VerenigingEvent> VerenigingEvent { get; set; }
    }
}
