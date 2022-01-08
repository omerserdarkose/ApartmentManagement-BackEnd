using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.Entities.Dtos.UserDetail;

namespace ApartmentManagement.Business.Abstract
{
    public interface IUserDetailService
    {
        IDataResult<UserDetailViewDto> GetById(int userId);

        IResult Add(UserDetailAddDto userDetailAdd);

        IResult Delete(int userId);

        IResult Update(UserDetailUpdateDto userDetailUpdate);
    }
}
