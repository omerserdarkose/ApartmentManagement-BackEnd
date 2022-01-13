using ApartmentManagement.Core.DataAccess;
using ApartmentManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
