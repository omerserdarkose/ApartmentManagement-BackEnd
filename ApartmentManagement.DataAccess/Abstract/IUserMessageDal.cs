using ApartmentManagement.Core.DataAccess;
using ApartmentManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Entities.Dtos.UserMessage;

namespace ApartmentManagement.DataAccess.Abstract
{
    public interface IUserMessageDal : IEntityRepository<UserMessage>
    {
        List<UserMessageIncomingViewDto> GetIncomingMessages(int userId);
        List<UserMessageSentViewDto> GetSentMessages(int userId);
    }
}

