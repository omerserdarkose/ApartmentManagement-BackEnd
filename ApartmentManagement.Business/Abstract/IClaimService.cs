using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.Entities.Dtos.Claim;

namespace ApartmentManagement.Business.Abstract
{
    public interface IClaimService
    {
        IDataResult<List<ClaimViewDto>> GetAll();

        IResult Add(ClaimAddDto claimAddDto);

        IResult Update(ClaimUpdateDto claimUpdateDto);
        IResult Delete(int claimId);

    }
}
