using ApartmentManagement.Core.DataAccess;
using ApartmentManagement.Entities.Concrete;
using ApartmentManagement.Entities.Dtos.Message;

namespace ApartmentManagement.DataAccess.Abstract
{
    public interface IMessageDal : IEntityRepository<Message>
    {
        int GetLastMessageId();
    }
}
