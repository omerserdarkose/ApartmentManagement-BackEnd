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
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Module = Autofac.Module;

namespace ApartmentManagement.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ExpenseTypeManager>().As<IExpenseTypeService>();
            builder.RegisterType<EfExpenseTypeDal>().As<IExpenseTypeDal>();
            
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<JWTHelper>().As<ITokenHelper>();

            builder.RegisterType<EfUserDetailDal>().As<IUserDetailDal>();
            builder.RegisterType<UserDetailManager>().As<IUserDetailService>();
            builder.RegisterType<BlockManager>().As<IBlockService>();

            //yurutulmekteolan tum assemblydeki implemente edilmis interfaceler icin interceptor ile mudahaleyi etkinlestiriyoruz> 
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
