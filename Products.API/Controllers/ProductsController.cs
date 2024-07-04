using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.API.Models;
using Products.API.Repository;

namespace Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products=_productRepository.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(Guid id)
        {
            var product = _productRepository.GetProductById(id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound($"Product with id = {id} is Not Found!!");
        }

        [HttpGet("amount/{amount}")]
        public IActionResult GetProductWithAmountGreaterThanSpecifiedAmount(double amount)
        {
            var products = _productRepository.GetProductsByAmount(amount);
            if (products != null)
            {
                return Ok(products);
            }
            return NotFound($"No products with amount greater than {amount} are found");

        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            var isProductAdded=_productRepository.AddProduct(product);
            if(isProductAdded)
            {
                return Ok(product);
            }           
            return StatusCode(500);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(Guid id, Product product)
        {
            var updateProduct = _productRepository.UpdateProduct(id, product);
            if (updateProduct != null)
            {
                //return Ok($"Product with id = {id} is updated successfully\n {updateProduct}");
                return Ok(updateProduct);
            }
            return NotFound($"Product with id = {id} is Not Found");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var isProductDeleted = _productRepository.DeleteProduct(id);
            if (isProductDeleted)
            {
                return Ok($"Product with id = {id} is deleted successfully");
            }
            return NotFound($"Product with id = {id} is Not Found");
        }
    }
}
