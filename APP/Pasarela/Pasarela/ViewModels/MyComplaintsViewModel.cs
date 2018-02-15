﻿using Pasarela.Core.Extensions;
using Pasarela.Core.Models.Complaints;
using Pasarela.Core.Services.Complaints;
using Pasarela.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pasarela.Core.ViewModels
{
    public class MyComplaintsViewModel: ViewModelBase
    {
        private ObservableCollection<Complaints> _complaints;
        private IComplaintsService _complaintsService;

        public MyComplaintsViewModel(IComplaintsService complaintsService)
        {
            _complaintsService = complaintsService;
        }

        public ObservableCollection<Complaints> ListComplaints
        {
            get { return _complaints; }
            set
            {
                _complaints = value;
                RaisePropertyChanged(() => ListComplaints);
            }
        }

        public async override Task InitializeAsync(object navigationData)
        {
            IsBusy = true;
            var complaintsList = await _complaintsService.GetComplaintsResolveAsync();
            foreach (var item in complaintsList)
            {
                //if (item.Photos.Count == 0)
                //{
                //    item.Photos.Add(new Models.PhotoComplaints.PhotoComplaints() { Photo = "ic_default" });
                //}
                var photo = item.Photos[0].Photo;
                photo = photo.Substring(23);
                byte[] bytes = Convert.FromBase64String(photo);
                Stream contents = new MemoryStream(bytes);
                item.PhotoPerfil = ImageSource.FromStream(() => { return contents; });
            }
            ListComplaints = complaintsList.ToObservableCollection();
            IsBusy = false;
        }

        public ICommand ViewDetailCommand => new Command(async (item) => await ViewDetailAsync(item));

        private async Task ViewDetailAsync(object item)
        {
            IsBusy = true;
            var complaints = item as Complaints;
            await NavigationService.NavigateToAsync<ComplaintDetailViewModel>(complaints);
            IsBusy = false;
        }

        public ICommand CommentsCommand => new Command(async (item) => await CommentsAsync(item));

        private async Task CommentsAsync(object item)
        {
            IsBusy = true;
            var complaints = item as Complaints;
            await NavigationService.NavigateToAsync<ComentComplaintsViewModel>(complaints);
            IsBusy = false;
        }

    }
}
