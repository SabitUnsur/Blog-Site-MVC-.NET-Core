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
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal _message2Dal;

        public Message2Manager(IMessage2Dal message2Dal)
        {
            _message2Dal = message2Dal;
        }

        public void Add(Message2 entity)
        {
            _message2Dal.Add(entity);
        }

        public void Delete(Message2 entity)
        {
            throw new NotImplementedException();
        }

        public Message2 GetByID(int entityID)
        {
           return _message2Dal.GetByID(entityID);
        }

        public List<Message2> GetInboxListByWriter(int receiverID)
        {
            return _message2Dal.GetInBoxWithMessageByWriter(receiverID);
        }

        public List<Message2> GetListAll()
        {
            throw new NotImplementedException();
        }

        public List<Message2> GetSendboxListByWriter(int receiverID)
        {
            return _message2Dal.GetSendBoxWithMessageByWriter(receiverID);  
        }

        public void Update(Message2 entity)
        {
            throw new NotImplementedException();
        }
    }
}
