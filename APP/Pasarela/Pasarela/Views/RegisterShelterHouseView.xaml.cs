using Pasarela.Core.Helpers;
using Pasarela.Core.Models.Common;
using Pasarela.Core.ViewModels.Base;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pasarela.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterShelterHouseView : ContentPage
    {
        public RegisterShelterHouseView()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<MessageHelper, bool>(this, MessageKeys.OpenCameraShelterHouse, (sender, args) =>
            {
                Camera();
            });

            async Task Camera()
            {
                await CrossMedia.Current.Initialize();
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera available.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = Guid.NewGuid().ToString()

                });

                if (file == null)
                    return;

                //await DisplayAlert("File Location", file.Path, "OK");
                if (image1.Source == null)
                {
                    image1.Source = ImageSource.FromStream(() =>
                    {

                        var stream = file.GetStream();
                        return stream;

                    });
                }
                else if (image1.Source != null && image2.Source == null)
                {
                    image2.Source = ImageSource.FromStream(() =>
                    {

                        var stream = file.GetStream();
                        return stream;

                    });
                }
                else if (image1.Source != null && image2.Source != null && image3.Source == null)
                {
                    image3.Source = ImageSource.FromStream(() =>
                    {

                        var stream = file.GetStream();
                        return stream;

                    });
                }
                else if (image1.Source != null && image2.Source != null && image3.Source != null)
                {
                    await DisplayAlert(Constants.MessageTitle.Message, "Solo se pueden registrar 3 fotos", Constants.MessageButton.OK);
                    
                }


                Stream imageStream = file.GetStream();
                byte[] bytes;
                using (var memoryStream = new MemoryStream())
                {
                    imageStream.CopyTo(memoryStream);
                    bytes = memoryStream.ToArray();
                }
                string base64 = Convert.ToBase64String(bytes);
                string photo = "data:image/jpeg;base64," + base64;
                MessagingCenter.Send(this, MessageKeys.SendData, photo);
            }
        }
    }
}