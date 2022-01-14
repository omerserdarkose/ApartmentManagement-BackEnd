using ApartmentManagement.Core.DataAccess.EntitiyFramework;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Concrete;
using System.Linq;
using ApartmentManagement.DataAccess.Context;

namespace ApartmentManagement.DataAccess.Concrete.EntityFramework
{
    public class EfMessageDal : EfEntityRepositoryBase<Message, ApartmentManagementDbContext>, IMessageDal
    {
        public int GetLastMessageId()
        {
            using (var context=new ApartmentManagementDbContext())
            {
                var id = context.Set<Message>().ToList().Last().Id;
                return id;
            }
        }
    }
}
