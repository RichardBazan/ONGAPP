using Pasarela.Core.Models.Banner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasarela.Core.Services.Home
{
   public interface IHomeService
    {
        Task<List<Banner>> GetBannerAsync();
    }
}
