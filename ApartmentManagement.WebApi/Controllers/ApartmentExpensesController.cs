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


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_apartmentExpenseManager.GetUnPaidPayments());
        }


        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
