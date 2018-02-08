using Pasarela.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasarela.Core.ViewModels
{
    public class MyDataViewModel : ViewModelBase
    {

        public MyDataViewModel()
        {

        }

        public override Task InitializeAsync(object navigationData)
        {
            return base.InitializeAsync(navigationData);
        }

    }
}
