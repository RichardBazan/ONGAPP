using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pasarela.Core.Models.Comment;
using Pasarela.Core.Services.RequestProvider;
using Pasarela.Core.Models.Common;

namespace Pasarela.Core.Services.Comment
{
    public class CommentService : ICommentService
    {
        IRequestProvider _requestProvider;

        public CommentService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<List<Models.Comment.Comment>> GetCommentByComplaintAsync(int complaintId)
        {
            string uri = GlobalSetting.Instance.MakeURI(GlobalSetting.Instance.ComentarioEndPoint,
            string.Format("/{0}" + Constants.MethodsService.METHOD_COMMENT_COMPLAINTS, complaintId));
            var listComments = await _requestProvider.GetAsync<List<Models.Comment.Comment>>(uri);
            return listComments;
        }

        public async Task<Models.Comment.Comment> SaveCommentAsync(Models.Comment.Comment _saveComment)
        {
            string uri = GlobalSetting.Instance.ComentarioEndPoint;
            var saveComment = await _requestProvider.PostAsync<Models.Comment.Comment>(uri, _saveComment).ConfigureAwait(false);
            return saveComment;
        }
    }
}
