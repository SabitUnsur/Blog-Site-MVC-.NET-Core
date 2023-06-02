using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NewsLetterManager : INewsLetterService
    {
        INewsLetterDal _newsLetterDal;

        public NewsLetterManager(INewsLetterDal newsLetterDal)
        {
            _newsLetterDal = newsLetterDal;
        }

        public void AddNewsLetter(NewsLetter newsLetter)
        {
            _newsLetterDal.Add(newsLetter);
        }

        public bool IsEmailSubscribed(NewsLetter email)
        {
            bool isSubscribed = _newsLetterDal.IsEmailSubscribed(email); 

            return isSubscribed;
        }
    }
}
