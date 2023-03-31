using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IBlogService
	{
		void AddBlog(Blog blog);
		void DeleteBlog(Blog blog);
		void UpdateBlog(Blog blog);
		List<Blog> GetBlogList();
		Blog GetByID(int blogID);
		List<Blog> GetBlogByID(int blogID);
		List<Blog> GetBlogListWithCategory();
	}
}
