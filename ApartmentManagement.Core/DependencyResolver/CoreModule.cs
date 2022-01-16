using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ApartmentManagement.Core.DependencyResolver
{
    //projelerimizin core katmanini ilgilendiren yani projeden bagimsiz her projemizde kullanabilecegimiz kodlari iceren katmaninda IoC islemlerimizi tek merkeze topluyoruz.
    //Business ile ilgili IoC islemlerini business katmaninda ve IoC container (Autofac) ile yapmistik
    //Core katmanimizi yani her projede kullanabilecegimiz IoC islemlerinin tanimini da bu katmanda ve asagida yazdigimiz Tool vasitasiyla yapicaz
    public class CoreModule : ICoreModule
    {
        //startup icerisinde ConfigureServices() icerisinde yazmak yerine burada yazip oraya ekliycez
        public void Load(IServiceCollection services)
        {

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }
    }
}
