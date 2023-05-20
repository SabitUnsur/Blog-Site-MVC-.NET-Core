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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Message entity)
        {
            throw new NotImplementedException();
        }

        public Message GetByID(int entityID)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetListAll()
        {
           return _messageDal.GetAllList();
        }

        public List<Message> GetInboxListByWriter(string param)
        {
            return _messageDal.GetAllList(x=>x.Receiver == param);
        }

        public void Update(Message entity)
        {
            throw new NotImplementedException();
        }
    }
}
