using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ApartmentManagement.Core.Utilities.Interceptors;
using Castle.DynamicProxy;

namespace ApartmentManagement.Core.Aspects.Autofac
{
    public class TransactionScopeAspect:MethodInterception
    {
        //Intercept methodu ile islem yapilan methodun yasam dongusunu override etmeye ihtiyacimiz var
        public override void Intercept(IInvocation invocation)
        {
            //transaction islemini baslaiyoruz
            using (TransactionScope transactionScope=new TransactionScope())
            {
                try
                {
                    //method calistiriliyor
                    invocation.Proceed();

                    //basarili ise transactionscope tamamlaniyor
                    transactionScope.Complete();
                }
                catch (Exception e)
                {
                    //hata alinirsa yapilan islemler iptal ediliyor
                    transactionScope.Dispose();

                    //alinan exeption OnException bolumune yollaniyor
                    OnException(invocation,e);
                    throw;
                }
            }
        }
    }
}
