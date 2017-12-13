using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasarela.Core.Models.Donate
{
    public class ProductDonate
    {
        public int IdDonate { get; set; }
        public List<DonateProduct.DonateProduct> ListProducts { get; set; }

    }
}
