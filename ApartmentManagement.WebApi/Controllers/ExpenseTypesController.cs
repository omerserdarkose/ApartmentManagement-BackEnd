using ApartmentManagement.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApartmentManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseTypesController : ControllerBase
    {
        private IExpeneTypeService _expeneTypeManager;

        public ExpenseTypesController(IExpeneTypeService expeneTypeManager)
        {
            _expeneTypeManager = expeneTypeManager;
        }

        // GET: api/<ExpenseTypesController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var result=_expeneTypeManager.GetAll();
            
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        // POST api/<ExpenseTypesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ExpenseTypesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ExpenseTypesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
