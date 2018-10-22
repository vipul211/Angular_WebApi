using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud_tmp.ViewModels;
using Infrastucture.Models;
using Infrastucture.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud_tmp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : RestController<Employee>
    {
        public EmployeeController(IDataService<Employee> employeeService)
        {
            _dataService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = _dataService.Query();

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(Guid id)
        {
            var employee = await _dataService.Get(id);

            if (employee != null)
                return Ok(employee);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeModel employeeModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await Create(employeeModel);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(Guid id,[FromBody] EmployeeModel employeeModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employee = await _dataService.Get(id);
            if (employee == null)
                return NotFound();

            employee.FirstName = employeeModel.FirstName;
            employee.LastName = employeeModel.LastName;
            employee.BirthDate = employeeModel.BirthDate;
            employee.PhoneNo = employeeModel.PhoneNo;
            employee.Email = employeeModel.Email;

            await _dataService.Update(employee);

            return Ok();
        }

        [HttpDelete("{id}")]
        public void DeleteEmployee(Guid id) => Delete<EmployeeModel>(id);
    }
}