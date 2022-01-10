using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.Entities.Dtos.UserMessage;

namespace ApartmentManagement.Business.Abstract
{
    public interface IUserMessageService
    {
        IResult AddMessageForOne(UserMessageSendToOneDto messageSendToOneDto);
        IResult AddMessageForAll(UserMessageSendToAllDto messageSendToAllDto);
    }
}
