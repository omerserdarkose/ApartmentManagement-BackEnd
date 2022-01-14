using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.Entities.Concrete;
using ApartmentManagement.Entities.Dtos.Payment;

namespace ApartmentManagement.Business.Abstract
{
    public interface IPaymentService
    {
        IResult Add(Payment addPayment);

        IDataResult<List<PaymentViewDto>> GetAll();
        IDataResult<List<PaymentViewDto>> GetByApartmentId(int apartmentId);
    }
}
