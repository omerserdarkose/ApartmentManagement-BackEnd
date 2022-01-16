using ApartmentManagement.Business.Abstract;
using ApartmentManagement.Business.Concrete;
using ApartmentManagement.Business.Mapping.AutoMapper;
using ApartmentManagement.Core.Entities;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.DataAccess.Concrete.EntityFramework;
using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Utilities.Interceptors;
using ApartmentManagement.Core.Utilities.Security;
using ApartmentManagement.Core.Utilities.Security.JWT;
using ApartmentManagement.DataAccess.Concrete.Mongo;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Module = Autofac.Module;

namespace ApartmentManagement.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ExpenseTypeManager>().As<IExpenseTypeService>().InstancePerRequest();
            builder.RegisterType<EfExpenseTypeDal>().As<IExpenseTypeDal>();
            
            builder.RegisterType<UserManager>().As<IUserService>().InstancePerRequest();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<EfUserDetailDal>().As<IUserDetailDal>();
            builder.RegisterType<UserDetailManager>().As<IUserDetailService>();

            builder.RegisterType<EfBlockDal>().As<IBlockDal>();
            builder.RegisterType<BlockManager>().As<IBlockService>();

            builder.RegisterType<EfApartmentDal>().As<IApartmentDal>();
            builder.RegisterType<ApartmentManager>().As<IApartmentService>();

            builder.RegisterType<EfApartmentExpenseDal>().As<IApartmentExpenseDal>();
            builder.RegisterType<ApartmentExpenseManager>().As<IApartmentExpenseService>();

            builder.RegisterType<EfMessageDal>().As<IMessageDal>();
            builder.RegisterType<MessageManager>().As<IMessageService>();

            builder.RegisterType<EfUserMessageDal>().As<IUserMessageDal>();
            builder.RegisterType<UserMessageManager>().As<IUserMessageService>();

            builder.RegisterType<EfCarDal>().As<ICarDal>();
            builder.RegisterType<CarManager>().As<ICarService>();

            builder.RegisterType<EfUserClaimDal>().As<IUserClaimDal>();
            builder.RegisterType<UserClaimManager>().As<IUserClaimService>();

            builder.RegisterType<EfClaimDal>().As<IClaimDal>();
            builder.RegisterType<ClaimManager>().As<IClaimService>();

            builder.RegisterType<EfExpenseDal>().As<IExpenseDal>();
            builder.RegisterType<ExpenseManager>().As<IExpenseService>();

            builder.RegisterType<MPaymentDal>().As<IPaymentDal>();
            builder.RegisterType<PaymentManager>().As<IPaymentService>();

            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<JWTHelper>().As<ITokenHelper>();

            //yurutulmekteolan tum assemblydeki implemente edilmis interfaceler icin interceptor ile mudahaleyi etkinlestiriyoruz> 
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
