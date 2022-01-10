using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Utilities.Result;

namespace ApartmentManagement.Business.Abstract
{
    public interface IMessageService
    {
        IDataResult<MessageViewDto> GetById(int messageId);


    }
}
