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
	public class BlogManager : IBlogService
	{
		IBlogDal _blogDal;

		public BlogManager(IBlogDal blogDal)
		{
			_blogDal = blogDal;
		}

		public void AddBlog(Blog blog)
		{
			throw new NotImplementedException();
		}

		public void DeleteBlog(Blog blog)
		{
			throw new NotImplementedException();
		}

		public Blog GetByID(int blogID)
		{
			throw new NotImplementedException();
		}

		public List<Blog> GetBlogByID(int blogID) 
		{
			return _blogDal.GetAllList(x => x.BlogID==blogID);
		}

		public List<Blog> GetBlogList()
		{
			return _blogDal.GetAllList();	
		}

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public void UpdateBlog(Blog blog)
		{
			throw new NotImplementedException();
		}

		public List<Blog> GetBlogListByWriter(int writerID)
		{
			return _blogDal.GetAllList(x=>x.WriterID==writerID);
		}
	}
}
