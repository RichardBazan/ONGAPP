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
    
    public partial class Adopcion
    {
        public int cod_adop { get; set; }
        public Nullable<System.DateTime> fecha_solic { get; set; }
        public string estado_adop { get; set; }
        public int cod_usu { get; set; }
        public int cod_mas { get; set; }
    
        public virtual Mascota Mascota { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}