using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T,TContext> : IGenericDal<T> where T : class, new() 
        where TContext : DbContext, new()
    {   
            TContext _context=new TContext();

        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public List<T> GetAllList()
        {
            return _context.Set<T>().ToList();
        }

		public List<T> GetAllList(Expression<Func<T, bool>> filter)
		{
			return _context.Set<T>().Where(filter).ToList();
		}

		public T GetByID(int ID)
        {
            return _context.Set<T>().Find(ID);
        }

		public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
