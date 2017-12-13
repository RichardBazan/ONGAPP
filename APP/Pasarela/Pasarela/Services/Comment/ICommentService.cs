using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pasarela.Core.Services.Comment
{
    public interface ICommentService
    {

        Task<List<Models.Comment.Comment>> GetCommentByComplaintAsync(int complaintId);

        Task<Models.Comment.Comment> SaveCommentAsync(Models.Comment.Comment _saveComment);

    }
}
