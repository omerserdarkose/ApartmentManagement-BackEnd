using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentManagement.Business.Abstract;


namespace ApartmentManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentExpensesController : ControllerBase
    {
        private IApartmentExpenseService _apartmentExpenseManager;

        public ApartmentExpensesController(IApartmentExpenseService apartmentExpenseManager)
        {
            _apartmentExpenseManager = apartmentExpenseManager;
        }


        [HttpGet("unpaid/{apartmentId}")]
        public IActionResult GetUnPaidPayments(int apartmentId)
        {
            return Ok(_apartmentExpenseManager.GetUnPaidPayments(apartmentId));
        }

        [HttpGet("paid/{apartmentId}")]
        public IActionResult GetPaidPayments(int apartmentId)
        {
            return Ok(_apartmentExpenseManager.GetPaidPayments(apartmentId));
        }

        [HttpGet("unpaid")]
        public IActionResult GetMyUnPaidPayments()
        {
            return Ok(_apartmentExpenseManager.GetMyUnPaidPayments());
        }

        [HttpGet("paid")]
        public IActionResult GetMyPaidPayments()
        {
            return Ok(_apartmentExpenseManager.GetMyPaidPayments());
        }


        [HttpPost]
        public void Post([FromBody] string value)
        {
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
