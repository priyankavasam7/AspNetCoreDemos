using EmployeeManagement.API.Models;

namespace EmployeeManagement.API.Contracts
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<bool> AddEmployee(Employee employee);
        Task<bool> DeleteEmployee(int id);
        Task<Employee> UpdateEmployee(int id, Employee employee);
    }
}
