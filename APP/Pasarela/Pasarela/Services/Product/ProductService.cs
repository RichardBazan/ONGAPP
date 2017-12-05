using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pasarela.Core.Models.Product;
using Pasarela.Core.Services.RequestProvider;
using Pasarela.Core.Models.Common;

namespace Pasarela.Core.Services.Product
{
    public class ProductService : IProductService
    {

        IRequestProvider _requestProvider;

        public ProductService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<List<Models.Product.Product>> GetAllProductsAsync()
        {
            string uri = GlobalSetting.Instance.MakeURI(GlobalSetting.Instance.ProductoEndPoint,
            string.Format(Constants.MethodsService.METHOD_ALL_PRODUCTS));
            var listProducts = await _requestProvider.GetAsync<List<Models.Product.Product>>(uri);
            return listProducts;
        }
    }
}
