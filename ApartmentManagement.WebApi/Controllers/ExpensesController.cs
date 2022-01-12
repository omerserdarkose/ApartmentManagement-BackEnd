using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentManagement.Business.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApartmentManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private IExpenseService _expenseManager;

        public ExpensesController(IExpenseService expenseManager)
        {
            _expenseManager = expenseManager;
        }


        // GET api/<ExpensesController>/5
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_expenseManager.GetList());
        }

        // POST api/<ExpensesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ExpensesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ExpensesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
