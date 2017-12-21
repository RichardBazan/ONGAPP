using Pasarela.Core.Extensions;
using Pasarela.Core.Models.Comment;
using Pasarela.Core.Models.Common;
using Pasarela.Core.Models.Complaints;
using Pasarela.Core.Services.Comment;
using Pasarela.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<Comment> _comment;
        private ICommentService _commentService;
        private string _comments;

        public ComentComplaintsViewModel(ICommentService commentService)
        {
            VisibleComment = false;
            _commentService = commentService;
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

        public ObservableCollection<Comment> ListComment
        {
            get { return _comment; }
            set
            {
                _comment = value;
                RaisePropertyChanged(() => ListComment);
            }
        }

        public string Comment
        {
            get { return _comments; }
            set
            {
                _comments = value;
                RaisePropertyChanged(() => Comment);
            }
        }

        public async override Task InitializeAsync(object navigationData)
        {
            IsBusy = true;
            var data = navigationData as Complaints;
            Complaint = data;
            var comment = await _commentService.GetCommentByComplaintAsync(Complaint.Id);
            ListComment = comment.ToObservableCollection();
            IsBusy = false;
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

        public ICommand ToCommentCommand => new Command(async () => await ToCommentAsync());

        private async Task ToCommentAsync()
        {
            try
            {
                var saveComment = new Comment()
                {
                    UserId= GlobalSetting.UserInfo.Id,
                    ComplaintId= Complaint.Id,
                    Description= Comment
                };
                await _commentService.SaveCommentAsync(saveComment);
                await DialogService.ShowAlertAsync("Se registro con éxito su comentario", Constants.MessageTitle.Message, Constants.MessageButton.OK);
                await NavigationService.NavigateBack(false);
            }
            catch (Exception ex)
            {
                await DialogService.ShowAlertAsync(ex.Message, Constants.MessageTitle.Error, Constants.MessageButton.OK);
            }
        }

    }
}
