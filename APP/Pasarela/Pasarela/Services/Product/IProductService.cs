using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasarela.Core.Services.Product
{
    public interface IProductService
    {

        Task<List<Pasarela.Core.Models.Product.Product>> GetAllProductsAsync();

    }
}
