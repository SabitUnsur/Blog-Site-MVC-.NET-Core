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

        public Blog GetByID(int entityID)
        {
            return _blogDal.GetByID(entityID);
        }

        public List<Blog> GetBlogByID(int blogID) 
		{
			return _blogDal.GetAllList(x => x.BlogID==blogID);
		}

		public List<Blog> GetBlogList()
		{
			return _blogDal.GetAllList();	
		}

		//Returns the last 3 posts
		public List<Blog> GetLatestBlog()
		{
			return _blogDal.GetAllList().TakeLast(3).ToList();
		}

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

		public List<Blog> GetBlogListByWriter(int writerID)
		{
			return _blogDal.GetAllList(x=>x.WriterID==writerID);
		}

        public List<Blog> GetListWithCategoryByWriter(int ID)
        {
			return _blogDal.GetListWithCategoryByWriter(ID);
        }

        public void Add(Blog entity)
        {
            _blogDal.Add(entity);
        }

        public void Delete(Blog entity)
        {
            _blogDal.Delete(entity);
        }

        public void Update(Blog entity)
        {
            _blogDal.Update(entity);
        }

        public List<Blog> GetListAll()
        {
            return _blogDal.GetAllList();
        }

    }
}
