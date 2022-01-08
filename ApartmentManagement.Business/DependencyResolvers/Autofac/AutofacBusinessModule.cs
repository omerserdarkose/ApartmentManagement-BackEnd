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
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Utilities.Security;
using ApartmentManagement.Core.Utilities.Security.JWT;

namespace ApartmentManagement.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ExpenseTypeManager>().As<IExpeneTypeService>();
            builder.RegisterType<EfExpenseTypeDal>().As<IExpenseTypeDal>();
            
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<JWTHelper>().As<ITokenHelper>();

            builder.RegisterType<EfUserDetailDal>().As<IUserDetailDal>();
            builder.RegisterType<UserDetailManager>().As<IUserDetailService>();
        }
    }
}
