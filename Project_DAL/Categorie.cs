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
    
    public partial class Categorie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Categorie()
        {
            this.VerenigingCategorie = new HashSet<VerenigingCategorie>();
        }
    
        public int id { get; set; }
        public string typeVereniging { get; set; }
        public string cultuur { get; set; }
        public string sport { get; set; }
        public string leeftijd { get; set; }
        public Nullable<bool> kansentarief { get; set; }
        public Nullable<bool> andersvalieden { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VerenigingCategorie> VerenigingCategorie { get; set; }
    }
}
