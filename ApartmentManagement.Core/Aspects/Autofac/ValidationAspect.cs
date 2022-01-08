using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.CrossCuttingConcern.Validation.FluentValidation;
using ApartmentManagement.Core.Utilities.Interceptors;
using ApartmentManagement.Core.Utilities.Messages;
using Castle.DynamicProxy;
using FluentValidation;

namespace ApartmentManagement.Core.Aspects.Autofac
{
    public class ValidationAspect : MethodInterception
    {
        //reflection ile validasyon yapilacak turu ogrenicez ve bu degiskene atama yapicaz
        private Type _validatorType;

        //constructor da hangi fluentValidation tipinde instance olusturulacagi bilgisi bekleniyor
        public ValidationAspect(Type validatorType)
        {
            //eger gelen obje IValidatordan turetilmemisse 
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                //hata veriliyor
                throw new Exception(AspectMessages.WrongValidationType);
            }

            _validatorType = validatorType;
        }

        //MethodInterceprion sinifinda tanimladigimiz ve ici bos olan methodlari
        //bu aspectte hangisi ihtiyacimiz ise ona gore override ederek aktiflestiriyoruz
        //ornegin burada OnBefore ihtiyacimiz
        protected override void OnBefore(IInvocation invocation)
        {
            //gelen validatorin tipini ogrenmistik
            //simdi kullanmak icin reflection ile o tipde bir instance olusturuyoruz
            var validator = (IValidator)Activator.CreateInstance(_validatorType);

            //bu validasyon ile hangi tipteki entity veya modellerin kontrolunun yapilacagini ogreniyoruz
            //ornegin gelen validator customerValidator ise
            //public class CustomerValidator:AbstractValidator<Customer> bu imzadaki Customer yazan kismi bu sekilde aliyoruz
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];

            //bu aspectin yazildigi methodun aldigi parametreleri gezip kontrol edecegimiz tipte olanlari topluyoruz
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

            //konrol edilecek tipte olanlarin herbiri icin validate methodunu cagiriyoruz ve arg olarak yukarida olusturdugumuz validator instancini ve gelen veriyi veriyoruz
            foreach (var entity in entities)
            {
                ValidatorTool.Validate(validator, entity);
            }

        }

    }
}

