//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetCSharp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ecole
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ecole()
        {
            this.Heritage = new HashSet<Heritage>();
        }
    
        public int EcoleID { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public int RegleID { get; set; }
    
        public virtual Regles Regles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Heritage> Heritage { get; set; }
    }
}
