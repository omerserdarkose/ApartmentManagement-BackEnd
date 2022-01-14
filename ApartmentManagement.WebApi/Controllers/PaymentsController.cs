using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentManagement.Business.Abstract;
using ApartmentManagement.Entities.Concrete;

namespace ApartmentManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private IPaymentService _paymentManager;

        public PaymentsController(IPaymentService paymentManager)
        {
            _paymentManager = paymentManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _paymentManager.GetAll();
            return Ok(result);
        }

        [HttpGet("filter")]
        public IActionResult GetOneApartmentPayments(int apartmentId)
        {
            var result = _paymentManager.GetByApartmentId(apartmentId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        [HttpPost]
        public IActionResult Post([FromBody] Payment payment)
        {
            var result = _paymentManager.Add(payment);
            if (!result.Success)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
