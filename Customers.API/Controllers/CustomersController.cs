using Customers.API.Models;
using Customers.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerEFRepository _customerRepository;
        public CustomersController(ICustomerEFRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers= _customerRepository.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        
        [HttpPost]
        public IActionResult AddCustomer([FromBody]CustomerEFCore customer)
        {
            var isCustomerAdded = _customerRepository.AddCustomer(customer);

            if(isCustomerAdded)
            {
                //return Ok(customer);
                return Ok($"Customer is added successfully!!");
            }
            return StatusCode(500);  
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer([FromRoute] int id, [FromBody] CustomerEFCore customer)
        {
            var updateCustomer=_customerRepository.UpdateCustomer(id, customer);
            if (updateCustomer==null)
            {
                return NotFound($"Customer with id={id} does not exist");
            }
            return Ok(updateCustomer);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customerDeleted= _customerRepository.DeleteCustomer(id);
            if (customerDeleted)
            {
                return Ok($"Customer with id = {id} deleted sucessfully!!");
            }
            return NotFound($"Customer with id ={id} is not found");
        }

    }
}











/*
* C - CREATE
* R - READ
* U - UPDATE
* D - DELETE
*/

/*
[HttpGet]
public string Customers()
{
    return "All Customers";
}
[HttpGet("{id}")]
public string Customers(int id)
{
    return "Customer";
}
*/