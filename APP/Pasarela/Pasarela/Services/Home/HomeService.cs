using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pasarela.Core.Models.Banner;

namespace Pasarela.Core.Services.Home
{
    public class HomeService : IHomeService
    {
        public Task<List<Banner>> GetBannerAsync()
        {
            throw new NotImplementedException();
        }
    }
}
