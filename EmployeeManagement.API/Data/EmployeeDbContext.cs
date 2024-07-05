using EmployeeManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Data
{
    public class EmployeeDbContext :DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var employeeOne = new Employee
            {
                Id = 1,
                Name = "Sudheer",
                Email = "sudheer@test.com",
                Salary = 30000
            };
            var employeeTwo = new Employee
            {
                Id = 2,
                Name = "Ramesh",
                Email = "Ramesh@test.com",
                Salary = 20000
            };
        modelBuilder.Entity<Employee>().HasData(employeeOne, employeeTwo);
        }
        public DbSet<Employee> employees { get; set; }
    }
}
