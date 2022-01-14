using ApartmentManagement.Core.DataAccess;
using ApartmentManagement.Entities.Concrete;
using System.Collections.Generic;
using ApartmentManagement.Entities.Dtos.Apartment;
using ApartmentManagement.Entities.Dtos.User;

namespace ApartmentManagement.DataAccess.Abstract
{
    public interface IApartmentDal : IEntityRepository<Apartment>
    {
        List<ApartmentViewDto> GetListWithDetails();
        List<int> GetApartmentIdList();

        List<UserViewDto> GetResidentList();
    }
}
