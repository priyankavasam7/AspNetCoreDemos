using EmployeeManagement.API.Contracts;
using EmployeeManagement.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IEmployeeRepository _employeeRepository;
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees=await _employeeRepository.GetEmployees();
            if (employees != null)
            {
                return Ok(employees);
            }
            return NotFound("No Records Found!!!");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _employeeRepository.GetEmployee(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound("No Records Found!!!");
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            var isEmployeeAdded=await _employeeRepository.AddEmployee(employee);
            if (isEmployeeAdded)
            {
                return Ok("Employee added Successfully!!!");
            }
            return StatusCode(500);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id , Employee employee)
        {
            var updateEmployee=await _employeeRepository.UpdateEmployee(id, employee);
            if(updateEmployee != null)
            {
                return Ok(updateEmployee);
            }
            return NotFound("Requested Employee Not Found!!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var isEmployeeDeleted=await _employeeRepository.DeleteEmployee(id);
            if (isEmployeeDeleted)
            {
                return Ok("Employee deleted successfully!!");
            }
            return NotFound("Requested employee Not Found!!");
        }

    }
}
