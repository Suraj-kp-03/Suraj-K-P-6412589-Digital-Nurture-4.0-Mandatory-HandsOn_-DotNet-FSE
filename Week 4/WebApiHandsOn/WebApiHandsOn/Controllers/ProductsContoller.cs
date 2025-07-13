using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiHandsOn.Models;

namespace WebApiHandsOn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsContoller : ControllerBase
    {
        private static List<Models.Product> products = new List<Models.Product>
        {
            new Models.Product { Id = 1, Name = "Laptop", Description = "Gaming Laptop", Price = 1200.00M },
            new Models.Product { Id = 2, Name = "Smartphone", Description = "Latest Model", Price = 800.00M },
            new Models.Product { Id = 3, Name = "Tablet", Description = "10-inch Display", Price = 300.00M }
        };
        [HttpGet]
        public ActionResult<IEnumerable<Models.Product>> GetProducts()
        {
            return Ok(products);
        }
        [HttpGet("{id}")]
        public ActionResult<Models.Product> GetProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null.");

            }
            product.Id = products.Max(p => p.Id) + 1; 
            products.Add(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, Product product)
        {
            if (product == null || id != product.Id)
            {
                return BadRequest("Product ID mismatch or product is null.");
            }
            var existingProduct = products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            products.Remove(product);
            return NoContent();
        }

    }
}

