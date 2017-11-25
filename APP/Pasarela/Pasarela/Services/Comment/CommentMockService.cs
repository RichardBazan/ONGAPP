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
            new Models.Comment.Comment{ Id = 1, Description="Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem ", ComplaintId=1, UserId=1, Like="ic_notlike.png"},
            new Models.Comment.Comment{ Id = 2, Description="Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem ", ComplaintId=1, UserId=1, Like="ic_notlike.png"},
            new Models.Comment.Comment{ Id = 3, Description="Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem ", ComplaintId=1, UserId=1, Like="ic_notlike.png"},
            new Models.Comment.Comment{ Id = 4, Description="Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem ", ComplaintId=1, UserId=1, Like="ic_notlike.png"}
        };

        public async  Task<List<Models.Comment.Comment>> GetCommentByComplaintAsync(int complaintId)
        {
            return MockListCommentBycomplaint;
        }
    }
}
