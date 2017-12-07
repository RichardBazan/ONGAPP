using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasarela.Core.Models.ShelterHouse
{
    public class SaveShelterHouse
    {

        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public int IdUser { get; set; }
        //public List<PhotoShelterHouse.PhotoShelterHouse> Photos { get; set; }

    }
}
