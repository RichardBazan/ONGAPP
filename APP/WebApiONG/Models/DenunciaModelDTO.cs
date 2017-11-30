using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiONG.Models
{
    public class DenunciaModelDTO
    {
        public int Id;

        public string Title;

        public string Description;

        public string Address;

        public string Phone;

        public string Breed;

        public List<FotoDenunciaModelDTO> Photos;


    }
}