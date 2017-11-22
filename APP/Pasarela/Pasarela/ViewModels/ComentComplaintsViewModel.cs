using Pasarela.Core.Models.Complaints;
using Pasarela.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pasarela.Core.ViewModels
{
    public class ComentComplaintsViewModel: ViewModelBase
    {

        private Complaints _complaint;
        private bool _visibleComment;

        public ComentComplaintsViewModel()
        {
            VisibleComment = false;
        }

        public Complaints Complaint
        {
            get { return _complaint; }
            set
            {
                _complaint = value;
                RaisePropertyChanged(() => Complaint);
            }
        }

        public bool VisibleComment
        {
            get { return _visibleComment; }
            set
            {
                _visibleComment = value;
                RaisePropertyChanged(() => VisibleComment);
            }
        }

        public override Task InitializeAsync(object navigationData)
        {
            var data = navigationData as Complaints;
            Complaint = data;
            return base.InitializeAsync(navigationData);
        }

        public ICommand CommentCommand => new Command(async () => await CommentAsync());

        private async Task CommentAsync()
        {
            VisibleComment = true;
        }

        public ICommand CancelCommentCommand => new Command(async () => await CancelCommentAsync());

        private async Task CancelCommentAsync()
        {
            VisibleComment = false;
        }

    }
}
