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
	public class WriterManager : IWriterService
	{
		IWriterDal _writerDal;

		public WriterManager(IWriterDal writerDal)
		{
			_writerDal = writerDal;
		}

        public void Add(Writer entity)
        {
            _writerDal.Add(entity);
        }

        public void Delete(Writer entity)
        {
            throw new NotImplementedException();
        }

        public Writer GetByID(int entityID)
        {
            return _writerDal.GetByID(entityID);
        }

        public List<Writer> GetListAll()
        {
            throw new NotImplementedException();
        }

        public List<Writer> GetWriterByID(int ID)
        {
            return _writerDal.GetAllList(x => x.WriterID == ID);
        }

        public void Update(Writer entity)
        {
            _writerDal.Update(entity);
        }
    }
}
