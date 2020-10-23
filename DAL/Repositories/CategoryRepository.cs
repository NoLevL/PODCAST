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
        }

        public void Create(Category category)
        {
            categoryList.Add(category);
            using (StreamWriter sw = File.AppendText(savedCategories))
            {
                sw.WriteLine(category);
            }
            throw new NotImplementedException();
        }

        public void Delete(int index)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(int index, Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
