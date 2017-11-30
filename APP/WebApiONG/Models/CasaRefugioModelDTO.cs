using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiONG.Models
{
    public class CasaRefugioModelDTO
    {

        public int Id;

        public string Name;

        public string Address;

        public string Phone;

        public string Description;

        public List<FotoCasaRefugioModelDTO> Photos;

    }
}