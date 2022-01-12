using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.Entities.Dtos.UserClaim;

namespace ApartmentManagement.Business.Abstract
{
    public interface IUserClaimService
    {
        IDataResult<List<UserClaimListViewDto>> GetUserClaimList();
        IResult Add(UserClaimAddDto userClaimAddDto);

        IResult AddDefault(int userId,short claimId=2);

        IResult Update(UserClaimUpdateDto userClaimUpdateDto);
        IResult Delete(int userClaimId);
    }
}
