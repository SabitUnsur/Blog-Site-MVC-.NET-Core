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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public AppUser GetByID(int entityID)
        {
            return _userDal.GetByID(entityID);
        }

        public List<AppUser> GetListAll()
        {
            throw new NotImplementedException();
        }

        public void Update(AppUser entity)
        {
            _userDal.Update(entity);
        }
    }
}
