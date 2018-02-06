using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasarela.Core.Models.PhotoShelterHouse
{
    public class SavePhotoShelterHouse
    {
        public int IdShelterHouse { get; set; }
        public List<PhotoShelterHouse> Photos { get; set; }
    }
}
