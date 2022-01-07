using ApartmentManagement.Entities.Concrete;
using ApartmentManagement.Entities.Dtos.ExpenseType;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Business.Mapping.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ExpenseType, ExpenseTypeViewDto>();
            CreateMap<ExpenseTypeAddDto, ExpenseType>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Trim()));
            CreateMap<ExpenseTypeDeleteDto, ExpenseType>();
            CreateMap<ExpenseTypeUpdateDto, ExpenseType>().ForMember(dest=>dest.Name,opt=>opt.MapFrom(src=>src.Name.Trim()));
        }
    }
}
