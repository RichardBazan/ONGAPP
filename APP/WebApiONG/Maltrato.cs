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
    
    public partial class Maltrato
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Maltrato()
        {
            this.Comentario = new HashSet<Comentario>();
            this.Foto_Maltrato = new HashSet<Foto_Maltrato>();
        }
    
        public int cod_mal { get; set; }
        public string titulo_mal { get; set; }
        public string dir_mal { get; set; }
        public string tel_cont { get; set; }
        public string descrip_mal { get; set; }
        public Nullable<System.DateTime> fecha_reg { get; set; }
        public string estado_mal { get; set; }
        public int cod_usu { get; set; }
        public int cod_raza { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comentario> Comentario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Foto_Maltrato> Foto_Maltrato { get; set; }
        public virtual Raza Raza { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
