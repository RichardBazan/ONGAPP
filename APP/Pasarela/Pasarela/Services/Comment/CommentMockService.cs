using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pasarela.Core.Models.Comment;

namespace Pasarela.Core.Services.Comment
{
    public class CommentMockService : ICommentService
    {

        private List<Models.Comment.Comment> MockListCommentBycomplaint = new List<Models.Comment.Comment>
        {
            new Models.Comment.Comment{ Description="Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem ", ComplaintId=1, UserId=1},
            new Models.Comment.Comment{ Description="Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem ", ComplaintId=1, UserId=1},
            new Models.Comment.Comment{ Description="Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem ", ComplaintId=1, UserId=1},
            new Models.Comment.Comment{ Description="Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem ", ComplaintId=1, UserId=1}
        };

        public async  Task<List<Models.Comment.Comment>> GetCommentByComplaintAsync(int complaintId)
        {
            return MockListCommentBycomplaint;
        }

        public Task<Models.Comment.Comment> SaveCommentAsync(Models.Comment.Comment _saveComment)
        {
            throw new NotImplementedException();
        }
    }
}
