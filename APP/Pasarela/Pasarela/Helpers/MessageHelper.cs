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

        public static void OpenCameraUser()
        {
            MessagingCenter.Send(GetInstance(), MessageKeys.OpenCameraUser, true);
        }

        public static void OpenCameraShelterHouse()
        {
            MessagingCenter.Send(GetInstance(), MessageKeys.OpenCameraShelterHouse, true);
        }

        public static void OpenCameraComplaints()
        {
            MessagingCenter.Send(GetInstance(), MessageKeys.OpenCameraComplaints, true);
        }

        public static void OpenCameraDog()
        {
            MessagingCenter.Send(GetInstance(), MessageKeys.OpenCameraDog, true);
        }

        public static void OpenCameraData()
        {
            MessagingCenter.Send(GetInstance(), MessageKeys.OpenCameraData, true);
        }

    }
}
