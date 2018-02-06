using Pasarela.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pasarela.Core.Helpers
{
    public class MessageHelper
    {

        private static MessageHelper instance;

        public static MessageHelper GetInstance()
        {
            if (instance == null)
            {
                instance = new MessageHelper();
            }
            return instance;
        }

        public static void OpenCameraMessage()
        {
            MessagingCenter.Send(GetInstance(), MessageKeys.OpenCamera, true);
        }

    }
}
