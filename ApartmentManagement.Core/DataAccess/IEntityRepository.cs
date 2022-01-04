using ApartmentManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Core.DataAccess
{
    // dataAccess katmanina hizmet eden farkli tipteki Interface lere hizmet edebilecek ve generic tip ile calisan temel interface
    // IProductDal, ICustomerDal gibi interfacelerin tanimlanan methodlar ayni fakat urettikleri instance farklidir asagidaki interface ile ayni methodlari tek bir yerde kontrol edebiliyoruz

    // T olarak alinacak ornek referans tip olmali(T:class)
    // veritabani nesnesi olmali(IEntity bunu sagliyor)
    // new lenebilir yani somut olmali
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        //listeleme func. icine bir filtre alabilecek eger almazsa da null deger alacak sekilde tanimlaniyor
        List<T> GetList(Expression<Func<T, bool>> filter = null);

        //tek bir nesne getirilirken belirli bir kriter olmali bu yuzden burada null opsiyonu yok
        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

    }
}
