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
    
    public partial class AyantDroit
    {
        public int ADrID { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string Age { get; set; }
        public string Sexe { get; set; }
        public string TypeHeritier { get; set; }
        public string Description { get; set; }
        public int NomenclatureID { get; set; }
    
        public virtual Heritier Heritier { get; set; }
    }
}
