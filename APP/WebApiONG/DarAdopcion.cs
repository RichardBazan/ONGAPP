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
    
    public partial class DarAdopcion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DarAdopcion()
        {
            this.Foto_DarAdopcion = new HashSet<Foto_DarAdopcion>();
        }
    
        public int cod_daradop { get; set; }
        public Nullable<System.DateTime> fecha_reg { get; set; }
        public string estado_daradop { get; set; }
        public int cod_usu { get; set; }
        public int cod_mas { get; set; }
    
        public virtual Mascota Mascota { get; set; }
        public virtual Usuario Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Foto_DarAdopcion> Foto_DarAdopcion { get; set; }
    }
}