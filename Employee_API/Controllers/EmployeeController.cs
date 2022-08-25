using Employee_API.Model;
using Employee_API.Repository;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace Employee_API.Controllers
{
    [Route("v1")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> getEmployees()
        {
            return await _employeeRepository.Get();
        }

        [HttpGet("(ID)")]
        public async Task<ActionResult<Employee>> getEmployees(int ID)
        {
            return await _employeeRepository.Get(ID);
        }

        [HttpPost]

        public async Task<ActionResult<Employee>> postEmployee([FromBody] Employee employee)
        {
            var newEmployee = await _employeeRepository.Create(employee);
            return CreatedAtAction(nameof(getEmployees), new { ID = newEmployee.ID }, newEmployee);
        }

        [HttpDelete]

        public async Task<ActionResult> Delete(int ID)
        {
            var employeeToDelete = await _employeeRepository.Get(ID);

            if (employeeToDelete == null)
                return NotFound();

            await _employeeRepository.Delete(employeeToDelete.ID);
            return NoContent();
        }

        [HttpPut]

        public async Task<ActionResult> putEmployee(int ID, [FromBody] Employee employee)
        {
            if (ID != employee.ID)
                return BadRequest();

            await _employeeRepository.Update(employee);
            return Ok();
        }
    }
}
