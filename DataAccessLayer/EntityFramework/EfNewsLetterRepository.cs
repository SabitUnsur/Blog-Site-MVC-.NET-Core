using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfNewsLetterRepository : GenericRepository<NewsLetter, Context>, INewsLetterDal
    {
        public bool IsEmailSubscribed(NewsLetter email)
        {
            using (var db = new Context())
            {
                return db.NewsLetters.Select(x=>x.Mail==email.Mail).Any();
            }
        }
    }
}
