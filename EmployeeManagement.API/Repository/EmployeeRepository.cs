using EmployeeManagement.API.Contracts;
using EmployeeManagement.API.Data;
using EmployeeManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        EmployeeDbContext _employeeDbContext;
        public EmployeeRepository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }
        public async Task<bool> AddEmployee(Employee employee)
        {
                _employeeDbContext.employees.Add(employee);
                await _employeeDbContext.SaveChangesAsync();
                return true;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var isEmployeeExists= await GetEmployee(id);
            if (isEmployeeExists != null)
            {
                _employeeDbContext.employees.Remove(isEmployeeExists);
                await _employeeDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var employee = await _employeeDbContext.employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null) return null;
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
           var employees= await _employeeDbContext.employees.ToListAsync();
            if (employees.Count == 0) return null;
            return employees;
        }

        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            var existingEmployee= await GetEmployee(id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Email = employee.Email;
                existingEmployee.Salary = employee.Salary;
                await _employeeDbContext.SaveChangesAsync();
                return existingEmployee;
            }
            return null;


        }
    }
}
