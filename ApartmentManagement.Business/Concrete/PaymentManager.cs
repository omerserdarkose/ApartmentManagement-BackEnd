using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApartmentManagement.Business.Abstract;
using ApartmentManagement.Core.Utilities.Result;
using ApartmentManagement.DataAccess.Abstract;
using ApartmentManagement.Entities.Concrete;
using ApartmentManagement.Entities.Dtos.Payment;
using AutoMapper;

namespace ApartmentManagement.Business.Concrete
{
    public class PaymentManager:IPaymentService
    {
        private IPaymentDal _paymentDal;
        private IMapper _mapper;

        public PaymentManager(IPaymentDal paymentDal, IMapper mapper)
        {
            _paymentDal = paymentDal;
            _mapper = mapper;
        }

        public IResult Add(Payment addPayment)
        {
            _paymentDal.Add(addPayment);
            return new SuccessResult();
        }

        public IDataResult<List<PaymentViewDto>> GetAll()
        {
            var paymentList = _paymentDal.GetList();
            var paymentViewList = _mapper.Map<List<PaymentViewDto>>(paymentList);
            return new SuccessDataResult<List<PaymentViewDto>>(paymentViewList);
        }

        public IDataResult<List<PaymentViewDto>> GetByApartmentId(int apartmentId)
        {
            var paymentList = _paymentDal.GetList(x=>x.ApartmentId==apartmentId);
            var paymentViewList = _mapper.Map<List<PaymentViewDto>>(paymentList);
            return new SuccessDataResult<List<PaymentViewDto>>(paymentViewList);
        }

    }
}
