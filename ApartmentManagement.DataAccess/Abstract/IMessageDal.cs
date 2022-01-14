using ApartmentManagement.Core.DataAccess;
using ApartmentManagement.Entities.Concrete;

namespace ApartmentManagement.DataAccess.Abstract
{
    public interface IMessageDal : IEntityRepository<Message>
    {
        int GetLastMessageId();
    }
}
