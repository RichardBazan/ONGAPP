using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pasarela.Core.Models.ShelterHouse
{
    public class ShelterHouse
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public List<PhotoShelterHouse.PhotoShelterHouse> Photos { get; set; }
        public ImageSource PhotoPerfil { get; set; }

    }
}
