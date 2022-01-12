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
        int Add(MessageAddDto messageAddDto);

        int GetLastMessageId();
    }
}
