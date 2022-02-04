using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.Entities.Concrete;
using ApartmentManagement.Entities.Dtos.Message;

namespace ApartmentManagement.Business.Abstract
{
    public interface IMessageService
    {
        IResult SendMessageToAll(MessageAddDto messageAddForAllDto);
        IResult SendMessageToOne(MessageAddForOneDto messageAddForOneDto);
        void Add(MessageAddDto messageAddDto);
        int GetLastMessageId();
        IDataResult<MessageViewDto> GetMessageById(int messageId);
    }
}
