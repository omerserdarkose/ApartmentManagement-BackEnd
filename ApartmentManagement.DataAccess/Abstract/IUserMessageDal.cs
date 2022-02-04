using System;
using ApartmentManagement.Core.DataAccess;
using ApartmentManagement.Entities.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;
using ApartmentManagement.Entities.Dtos.UserMessage;

namespace ApartmentManagement.DataAccess.Abstract
{
    public interface IUserMessageDal : IEntityRepository<UserMessage>
    {
        List<UserMessageIncomingViewDto> GetIncomingMessages(int userId);
        List<UserMessageSentViewDto> GetSentMessages(int userId);
    }
}

