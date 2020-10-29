using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.Repositories
{
   public class CategoryRepository : ICategoryRepository<Category>
    {
        DataManager dataManager;
        List<Category> categoryList;

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
            //using (StreamWriter sw = File.AppendText(savedCategories))
            //{
            //    sw.WriteLine(category);
            //}
            //throw new NotImplementedException();
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
