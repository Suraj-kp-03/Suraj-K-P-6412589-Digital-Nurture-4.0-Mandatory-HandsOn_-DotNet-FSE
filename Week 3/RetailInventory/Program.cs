using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RetailInventory.Data;
using RetailInventory.Models;
using RetailInventory.Repositories;
using RetailInventory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RetailInventory
{
    class Program
    {
        public static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    var connectionString = context.Configuration.GetConnectionString("DefaultConnection");
                    services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer(connectionString));
                    services.AddScoped<IProductRepository, ProductRepository>();
                    services.AddScoped<ICategoryRepository, CategoryRepository>();
                    services.AddScoped<CategoryService>();
                    services.AddScoped<ProductService>();
                })
                .Build();
            host.Services.GetRequiredService<AppDbContext>().Database.Migrate();
            var categoryService = host.Services.GetRequiredService<CategoryService>();
            var productService = host.Services.GetRequiredService<ProductService>();


            // Example usage of the CategoryService 
            Category Electronics = new Category
            {
                Name = "Electronics"
            };
            Category Groceries = new Category
            {
                Name = "Groceries"
            };
            categoryService.AddCategoryAsync(Electronics);
            categoryService.AddCategoryAsync(Groceries);
            Console.WriteLine("Category as Added Successfully");
            var categories = categoryService.GetAllCategoriesAsync();
            var allCategories = categoryService.GetAllCategoriesAsync();
            foreach (var category in allCategories)
            {
                Console.WriteLine($"Category ID: {category.Id}, Name: {category.Name}");
            }
            Product Laptop = new Product
            {
                Name = "Laptop",
                Price = 75000,
                CategoryId = 1
            };
            Product RiceBag = new Product
            {
                Name = "Rice Bag",
                Price = 1200,
                CategoryId = 2
            };
            productService.AddProductAsync(Laptop);
            productService.AddProductAsync(RiceBag);
            Console.WriteLine("Producst as Added Successfully");
            Console.WriteLine("Products in the inventory:");
            productService.GetAllProductsAsync();
            productService.GetProductByIdAsync(11);
            productService.GetProductByIdAsync(12);
            productService.FirstOrDefaultAsync();
        }
    }
}
         
  