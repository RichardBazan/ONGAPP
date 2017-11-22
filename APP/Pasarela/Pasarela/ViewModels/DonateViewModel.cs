using Pasarela.Core.Models.ShelterHouse;
using Pasarela.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasarela.Core.ViewModels
{
    public class DonateViewModel : ViewModelBase
    {
        private ShelterHouse _shelterHouse;

        public DonateViewModel()
        {

        }

        public ShelterHouse ShelterHouse
        {
            get { return _shelterHouse; }
            set
            {
                _shelterHouse = value;
                RaisePropertyChanged(() => ShelterHouse);
            }
        }

        public override Task InitializeAsync(object navigationData)
        {
            var data = navigationData as ShelterHouse;
            ShelterHouse = data;
            return base.InitializeAsync(navigationData);
        }

    }
}
