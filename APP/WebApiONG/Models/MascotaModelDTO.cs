using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiONG.Models
{
    public class MascotaModelDTO
    {

        public int Id;

        public string Name;

        public string Description;

        public string Breed;

        public string Tenure;

        public string State;

        public List<FotoMascotaModelDTO> Photos;

    }
}