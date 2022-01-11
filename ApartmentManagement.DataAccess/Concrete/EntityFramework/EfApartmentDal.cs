using ApartmentManagement.Core.DataAccess.EntitiyFramework;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Entities.Dtos.Apartment;

namespace ApartmentManagement.DataAccess.Concrete.EntityFramework
{
    public class EfApartmentDal : EfEntityRepositoryBase<Apartment, ApartmentManagementDbContext>, IApartmentDal
    {
        public List<ApartmentViewDto> GetListWithDetails()
        {

            using (var context = new ApartmentManagementDbContext())
            {
                var result = from a in context.Apartments
                             join b in context.Blocks
                                 on a.BlockId equals b.Id
                             join u in context.Users
                                on a.OwnerId equals u.Id
                             join u2 in context.Users
                                 on a.HirerId equals u2.Id into bb
                             from hirer in bb.DefaultIfEmpty()
                             select new ApartmentViewDto()
                             {
                                 Id = a.Id,
                                 OwnerId = a.OwnerId,
                                 OwnerName = u.FirstName + " " + u.LastName,
                                 HirerId = hirer.Id,
                                 HirerName = hirer.FirstName==null?null:(hirer.FirstName+ " " + hirer.LastName),
                                 BlockId = a.BlockId,
                                 Block = b.Letter,
                                 Floor = a.Floor,
                                 DoorNumber = a.DoorNumber,
                                 Status = a.Status,
                                 Type = a.Type
                             };
                return result.ToList();
            }
        }
    }
}
