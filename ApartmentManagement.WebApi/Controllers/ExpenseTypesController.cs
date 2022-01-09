using ApartmentManagement.Business.Abstract;
using ApartmentManagement.Entities.Dtos.ExpenseType;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


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


        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _expeneTypeManager.GetAll();

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ExpenseTypeAddDto newExpenseType)
        {
            var result = _expeneTypeManager.Add(newExpenseType);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update([FromBody] ExpenseTypeUpdateDto updateExpenseType)
        {
            var result = _expeneTypeManager.Update(updateExpenseType);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int deleteExpenseTypeId)
        {
            var result = _expeneTypeManager.Delete(deleteExpenseTypeId);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
    }
}
