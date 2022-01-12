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
using ApartmentManagement.Entities.Dtos.Apartment;
using ApartmentManagement.Entities.Dtos.ApartmentExpense;
using ApartmentManagement.Entities.Dtos.Block;
using ApartmentManagement.Entities.Dtos.Car;
using ApartmentManagement.Entities.Dtos.Claim;
using ApartmentManagement.Entities.Dtos.Expense;
using ApartmentManagement.Entities.Dtos.Message;
using ApartmentManagement.Entities.Dtos.User;
using ApartmentManagement.Entities.Dtos.UserClaim;
using ApartmentManagement.Entities.Dtos.UserDetail;
using ApartmentManagement.Entities.Dtos.UserMessage;
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

            CreateMap<UserAddWithDetailsDto, User>();
            CreateMap<UserAddWithDetailsDto, UserDetailAddDto>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.IdentityNo, opt => opt.MapFrom(src => src.IdentityNo));

            CreateMap<UserAddWithDetailsDto, Apartment>();

            CreateMap<UserClaimsViewDto, Claim>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ClaimName));
            CreateMap<User, UserUpdateDto>();
            CreateMap<User, UserViewDto>();
            CreateMap<UserViewDto, User>();
            CreateMap<UserUpdateDto, User>();

            CreateMap<UserDetailAddDto, UserDetail>();
            CreateMap<UserDetailUpdateDto, UserDetail>();
            CreateMap<UserMessageSendToOneDto, MessageAddDto>();
            CreateMap<UserMessageSendToAllDto, MessageAddDto>();
            CreateMap<UserMessageSendToOneDto, UserMessage>()
                .ForMember(dest => dest.ToUserId, opt => opt.MapFrom(src => src.RecipientId));
            CreateMap<UserMessageSendToAllDto, UserMessage>();
            CreateMap<MessageAddDto, Message>();

            CreateMap<Block, BlockViewDto>();
            CreateMap<BlockAddDto, Block>();
            CreateMap<ApartmentAddDto, Apartment>();
            CreateMap<CarAddDto, Car>();
            CreateMap<UserAddWithDetailsDto, ApartmentUserUpdateDto>();
            CreateMap<UserClaimUpdateDto, UserClaim>();
            CreateMap<ClaimAddDto, Claim>();
            CreateMap<ExpenseAddDto, Expense>();
            CreateMap<ExpenseUpdateDto, Expense>();
            CreateMap<ExpenseAddForOneDto, ExpenseAddDto>();
            CreateMap<ApartmentExpenseAddDto, ApartmentExpense>();






        }
    }
}
