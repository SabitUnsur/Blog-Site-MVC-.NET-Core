using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessage2Repository : GenericRepository<Message2, Context>, IMessage2Dal
    {
        public List<Message2> GetListWithMessageByWriter(int writerID)
        {
            using (var context = new Context())
            {   
                return context.Message2s.Include(x=>x.SenderUser).Where(x=>x.ReceiverID==writerID).ToList();

            }
        }
    }
}
