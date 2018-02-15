using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pasarela.Core.Models.Dog
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Breed { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string State { get; set; }
        public string Tenure { get; set; }
        public List<PhotoDog.PhotoDog> Photos { get; set; }
        public ImageSource PhotoPerfil { get; set; } 
    }
}
