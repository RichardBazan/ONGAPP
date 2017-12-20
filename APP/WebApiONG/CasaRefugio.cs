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
    
    public partial class CasaRefugio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CasaRefugio()
        {
            this.Donaciones = new HashSet<Donaciones>();
            this.Foto_CasaRefugio = new HashSet<Foto_CasaRefugio>();
        }
    
        public int cod_casa { get; set; }
        public string nom_casa { get; set; }
        public string dir_casa { get; set; }
        public string tel_cont { get; set; }
        public string descrip_casa { get; set; }
        public Nullable<System.DateTime> fecha_reg { get; set; }
        public string estado_casa { get; set; }
        public int cod_usu { get; set; }
    
        public virtual Usuario Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Donaciones> Donaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Foto_CasaRefugio> Foto_CasaRefugio { get; set; }
    }
}
