using RetailInventory.Models;
using RetailInventory.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailInventory.Services
{
    class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public List<Category> GetAllCategoriesAsync()
        {
            return _categoryRepository.GetAll();
        }
        public Category GetCategoryByIdAsync(int id)
        {
            return _categoryRepository.GetById(id);
        }
        public void AddCategoryAsync(Category category)
        {
            _categoryRepository.Add(category);
        }

    }
}