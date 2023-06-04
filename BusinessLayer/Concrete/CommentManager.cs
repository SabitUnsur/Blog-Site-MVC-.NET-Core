using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void AddComment(Comment comment)
        {
            _commentDal.Add(comment);
        }
        public List<Comment> GetCommentList(int blogID)
        {
            return _commentDal.GetAllList(x => x.BlogID == blogID);
        }

        public List<Comment> GetCommentListWithBlog()
        {
            return _commentDal.GetListWithBlog();
        }
    }
}
