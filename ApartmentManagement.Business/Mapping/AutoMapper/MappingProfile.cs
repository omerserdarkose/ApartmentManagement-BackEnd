using ApartmentManagement.Entities.Concrete;
using ApartmentManagement.Entities.Dtos.ExpenseType;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Entities.Concrete;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.Entities.Dtos.User;
using ApartmentManagement.Entities.Dtos.UserDetail;
using Autofac.Features.Scanning;

namespace ApartmentManagement.Business.Mapping.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ExpenseType, ExpenseTypeViewDto>();
            CreateMap<ExpenseTypeAddDto, ExpenseType>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Trim()));

            CreateMap<ExpenseTypeDeleteDto, ExpenseType>();
            CreateMap<ExpenseTypeUpdateDto, ExpenseType>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Trim()));

            CreateMap<UserAddDto, UserForRegisterDto>();
            CreateMap<UserAddDto, UserDetail>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.IdentityNo, opt => opt.MapFrom(src => src.IdentityNo));

            CreateMap<UserAddDto, Apartment>();

            CreateMap<UserClaimsViewDto, Claim>()
                .ForMember(dest=>dest.Name,opt=>opt.MapFrom(src=>src.ClaimName));
            CreateMap<User, UserUpdateDto>();
            CreateMap<User, UserViewDto>();
            CreateMap<UserViewDto, User>();
            CreateMap<UserUpdateDto, User>();


            CreateMap<UserDetailAddDto,UserDetail>();
            CreateMap<UserDetailUpdateDto, UserDetail>();




        }
    }
}
