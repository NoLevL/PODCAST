using System;
using System.Collections.Generic;
using Models;

namespace DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository<Category>
    {
        private readonly DataManager dataManager;
        private readonly List<Category> categoryList;

            public CategoryRepository()
            {
                categoryList = new List<Category>();
                dataManager = new DataManager();
                categoryList = GetAll();
            }

        public void Create(Category category)
        {
            categoryList.Add(category);
            SaveChanges();
        }

        public void Delete(int index)
        {
            categoryList.RemoveAt(index);
            SaveChanges();
        }

        public void Delete(string aString)
        {

        }

        public List<Category> GetAll()
        {
            List<Category> categoryListToBeReturned = new List<Category>();
            try
            {
                categoryListToBeReturned = dataManager.ReturnCategories();
            }
            catch (Exception)
            {
            }
            return categoryListToBeReturned;
        }

        public void SaveChanges()
        {
            dataManager.SaveCategoryList(categoryList);
        }

        public void Update(int index, Category category)
        {
            if (index >= 0)
            {
                categoryList[index] = category;
            }
            SaveChanges();
        }

    }
}
