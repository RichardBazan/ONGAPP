//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiONG
{
    using System;
    using System.Collections.Generic;
    
    public partial class Mascota
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mascota()
        {
            this.Adopcion = new HashSet<Adopcion>();
            this.DarAdopcion = new HashSet<DarAdopcion>();
            this.Foto_Mascota = new HashSet<Foto_Mascota>();
        }
    
        public int cod_mas { get; set; }
        public string nom_mas { get; set; }
        public string sexo_mas { get; set; }
        public string edad_mas { get; set; }
        public string descrip_mas { get; set; }
        public string estado_mas { get; set; }
        public string tenencia { get; set; }
        public int cod_raza { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Adopcion> Adopcion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DarAdopcion> DarAdopcion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Foto_Mascota> Foto_Mascota { get; set; }
        public virtual Raza Raza { get; set; }
    }
}
