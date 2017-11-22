using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pasarela.Core.Interfaces
{
    public interface IPageLifeCylceEvents
    {
        void OnAppearing();
        void OnDisappearing();
    }
}
