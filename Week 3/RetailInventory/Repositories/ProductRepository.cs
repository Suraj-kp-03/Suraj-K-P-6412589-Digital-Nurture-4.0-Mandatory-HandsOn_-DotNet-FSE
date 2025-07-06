using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailInventory.Data;
using RetailInventory.Models;

namespace RetailInventory.Repositories
{
    class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }
        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }
        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void FirstOrDefaultAsync()
        {
            var product = _context.Products.FirstOrDefault();
            if (product != null)
            {
                Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            }
            else
            {
                Console.WriteLine($"Product No Product is greater than 50000.");
            }
        }
    }
}
