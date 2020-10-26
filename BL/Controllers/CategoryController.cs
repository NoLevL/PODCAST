using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using DAL.Repositories;
using Models;

namespace BL.Controllers
{
    public class CategoryController
    {
        private ICategoryRepository<Category> categoryRepository;

        public CategoryController()
        {
            categoryRepository = new CategoryRepository();
        }

        public void CreateCategoryObject(string name)
        {
            Category newCategory = null;
            if (newCategory == null) // Validering om kategorin finns eller inte.
            {
                newCategory = new Category(name);
            }
            categoryRepository.Create(newCategory);
        }

        public List<Category> RetrieveAllCategories()
        {
            return categoryRepository.GetAll();
        }

        public void UpdateCategoryObject(int index, Category category)//Ej testad än
        {
            Category updateCategory = null;
            if (updateCategory == null)
            {
                updateCategory = new Category(category.Name);
            }
            categoryRepository.Update(index, category);
        }

        public void DeleteCategory(int index)
        {
            //int index = categoryRepository.GetIndex(name);
            categoryRepository.Delete(index);
        }

        

        
    }
}
