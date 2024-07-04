using Microsoft.AspNetCore.Http.HttpResults;
using Products.API.Models;

namespace Products.API.Repository
{
    public class ProductInMemoryRepository : IProductRepository
    {
        public List<Product> _productList = new List<Product>();
        public ProductInMemoryRepository()
        {
            _productList.Add(new Product { Name = "Bottle", Description = "For driniking", Amount = 80.5 });
            _productList.Add(new Product { Name = "Chair", Description = "For sitting", Amount = 200.75 });
            _productList.Add(new Product { Name = "Table", Description = "For studying", Amount = 1500 });
            _productList.Add(new Product { Name = "Bag", Description = "For keeping books", Amount = 200.50 });
        }
        public bool AddProduct(Product product)
        {
            if (product == null) return false;
            _productList.Add(product);
            return true;
        }

        public bool DeleteProduct(Guid id)
        {
            var existingProduct = _productList.FirstOrDefault(x => x.Id == id);
            if (existingProduct != null)
            {
                _productList.Remove(existingProduct);
                return true;
            }
            return false;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productList;
        }

        public Product GetProductById(Guid id)
        {
            var product = _productList.FirstOrDefault(x => x.Id == id);
            return product;
        }

        public IEnumerable<Product> GetProductsByAmount(double amount)
        {
            List<Product> products = new List<Product>();
            foreach (var product in _productList)
            {
                if (product.Amount > amount) products.Add(product);
            }
            return products;
        }

        public Product UpdateProduct(Guid id, Product product)
        {
            var existingProduct = _productList.FirstOrDefault(p => p.Id == id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Amount = product.Amount;
                return existingProduct;
            }
            return null;
        }
    }
}
