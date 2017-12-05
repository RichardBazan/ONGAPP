﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pasarela.Core.Models.Donate;
using Pasarela.Core.Services.RequestProvider;
using Pasarela.Core.Models.Common;

namespace Pasarela.Core.Services.Donate
{
    public class DonateService : IDonateService
    {

        IRequestProvider _requestProvider;

        public DonateService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }


        public async Task<List<Models.Donate.Donate>> GetDonateByShelterHouseAsync(int shelterHouseId)
        {
            string uri = GlobalSetting.Instance.MakeURI(GlobalSetting.Instance.DonacionEndPoint,
            string.Format("/{0}" + Constants.MethodsService.METHOD_DONATE_SHELTERHOUSE, shelterHouseId));
            var listDonate = await _requestProvider.GetAsync<List<Models.Donate.Donate>>(uri);
            return listDonate;
        }
    }
}