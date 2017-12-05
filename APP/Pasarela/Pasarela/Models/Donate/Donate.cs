using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasarela.Core.Models.Donate
{
    public class Donate
    {

        public int Id { get; set; }
        public int IdUser { get; set; }
        public string User { get; set; }
        public int IdShelterHouse { get; set; }
        public string ShelterHouse { get; set; }
        public List<DonateProduct.DonateProduct> Products { get; set; }

    }
}
