using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentRepository : GenericRepository<Comment, Context>, ICommentDal
    {
        public List<Comment> GetListWithBlog()
        {
            using (var context = new Context())
            {
                return context.Comments.Include(c => c.Blog).ToList();
            }
        }
    }
}
