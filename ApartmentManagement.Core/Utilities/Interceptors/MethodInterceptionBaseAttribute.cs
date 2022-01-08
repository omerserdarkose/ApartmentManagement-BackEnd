using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace ApartmentManagement.Core.Utilities.Interceptors
{
    /// <summary>
    /// kullanacagimiz butun method interceptorlari icin genel ozellikleri iceren bir baseAttribute sinifi olusturuyoruz
    /// </summary>

    //bu attribute methodlara uygulanabilir,birden fazla kez kullanilabilir
    [AttributeUsage(AttributeTargets.Method|AttributeTargets.Class,AllowMultiple = true)]
    public abstract class MethodInterceptionBaseAttribute:Attribute,IInterceptor
    {
        public int Priority { get; set; }
        public virtual void Intercept(IInvocation invocation)
        {
            throw new NotImplementedException();
        }
    }
}
