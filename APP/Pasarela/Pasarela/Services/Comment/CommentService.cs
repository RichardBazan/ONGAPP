using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pasarela.Core.Models.Comment;

namespace Pasarela.Core.Services.Comment
{
    public class CommentService : ICommentService
    {
        public Task<List<Models.Comment.Comment>> GetCommentByComplaintAsync(int complaintId)
        {
            throw new NotImplementedException();
        }
    }
}
