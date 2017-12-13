using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasarela.Core.Models.Dog
{
    public class SaveDog
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public int IdBreed{ get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public int IdUser { get; set; }

}
}
