using System.Collections.Generic;
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
            if (newCategory == null)
            {
                newCategory = new Category(name);
            }
            categoryRepository.Create(newCategory);
        }

        public List<Category> RetrieveAllCategories()
        {
            return categoryRepository.GetAll();
        }

        public void UpdateCategoryObject(int index, string oldCategory, Category updateCategory)
        {
            
            if (updateCategory == null)
            {
                updateCategory = new Category(updateCategory.Name);
            }
            categoryRepository.Update(index, updateCategory);
            PodcastRepository podRepo = new PodcastRepository();
            var podList = podRepo.GetAll();
            foreach (var item in podList)
            {
                if (item.Category.Equals(oldCategory))
                {
                    item.Category = updateCategory.Name;
                }
            }
            podRepo.SaveChanges(podList);
        }

        public void DeleteCategory(int index)
        {
            categoryRepository.Delete(index);
        }

        

        
    }
}
