using ApartmentManagement.Core.DataAccess.EntitiyFramework;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using ApartmentManagement.DataAccess.Context;
using ApartmentManagement.Entities.Dtos.Apartment;
using ApartmentManagement.Entities.Dtos.User;

namespace ApartmentManagement.DataAccess.Concrete.EntityFramework
{
    public class EfApartmentDal : EfEntityRepositoryBase<Apartment, ApartmentManagementDbContext>, IApartmentDal
    {
        public List<ApartmentViewDto> GetListWithDetails()
        {

            using (var context = new ApartmentManagementDbContext())
            {
                var result = (from apartment in context.Apartments
                    join block in context.Blocks
                        on apartment.BlockId equals block.Id
                    join user in context.Users
                        on apartment.OwnerId equals user.Id
                    join user2 in context.Users
                        on apartment.HirerId equals user2.Id into bb
                    from hirer in bb.DefaultIfEmpty()
                    select new ApartmentViewDto()
                    {
                        Id = apartment.Id,
                        OwnerId = apartment.OwnerId,
                        OwnerName = user.FirstName + " " + user.LastName,
                        HirerId = hirer.Id,
                        HirerName = hirer.FirstName == null ? null : (hirer.FirstName + " " + hirer.LastName),
                        BlockId = apartment.BlockId,
                        Block = block.Letter,
                        Floor = apartment.Floor,
                        DoorNumber = apartment.DoorNumber,
                        Status = apartment.Status,
                        Type = apartment.Type
                    }).OrderBy(x=>x.Block).ThenBy(x=>x.DoorNumber);
                return result.ToList();
            }
        }

        public List<UserViewDto> GetResidentList()
        {
            using (var context = new ApartmentManagementDbContext())
            {
                var result = (from apartment in context.Apartments
                    join block in context.Blocks
                        on apartment.BlockId equals block.Id
                    join owner in context.Users
                        on apartment.OwnerId equals owner.Id
                    join hirer in context.Users
                        on apartment.HirerId equals hirer.Id into aa
                    from hirer in aa.DefaultIfEmpty()
                    join ownerDetail in context.UserDetails
                        on owner.Id equals ownerDetail.Id
                    join hirerDetail in context.UserDetails
                        on hirer.Id equals hirerDetail.Id into bb
                    from hirerDetail in bb.DefaultIfEmpty()
                    where apartment.IsActive == true
                    select new UserViewDto()
                    {
                        Id = (int)(hirer.FirstName == null ? apartment.OwnerId : hirer.Id),
                        Name = hirer.FirstName == null
                            ? owner.FirstName + " " + owner.LastName
                            : hirer.FirstName + " " + hirer.LastName,
                        PhoneNumber = hirer.FirstName == null ? ownerDetail.PhoneNumber : hirerDetail.PhoneNumber,
                        Email = hirer.FirstName == null ? owner.Email : hirer.Email,
                        Block = block.Letter.ToUpper(),
                        DoorNumber = apartment.DoorNumber,
                        Title = hirer.FirstName == null ? "Owner" : "Hirer"
                    }).OrderBy(x => x.Block).ThenBy(x => x.DoorNumber);
                return result.ToList();
            }
        }

        public List<int> GetApartmentIdList()
        {
            using (var context=new ApartmentManagementDbContext())
            {
                var result = context.Set<Apartment>().Where(x=>x.IsActive==true).Select(x => x.Id).ToList();
                return result;
            }
        }
    }
}
