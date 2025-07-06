using RetailInventory.Models;
using RetailInventory.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailInventory.Services
{
    class ProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void GetAllProductsAsync()
        {
            var products = _productRepository.GetAll();
            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            }
        }
        public void GetProductByIdAsync(int id)
        {
            var product = _productRepository.GetById(id);
            if (product != null)
            {
                Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, CategoryID: {product.CategoryId} ");
            }
            else
            {
                Console.WriteLine($"Product with ID {id} not found.");
            }
        }
        public void AddProductAsync(Product product)
        {
            _productRepository.Add(product);
            Console.WriteLine($"Product {product.Name} added successfully.");
        }
    }
}
