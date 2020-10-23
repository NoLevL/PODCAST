using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Category
    {

        public void AddCategory(string category)
        {
            categories.Add(category);
            using (StreamWriter sw = File.AppendText(savedCategories))
            {
                sw.WriteLine(category);
            }
        }

        //public void DeleteCategory(string category)
        //{
        //    categories.Remove(category);
        //    UpdateCategories(categories);
        //}

        //public void EditCategory(string categoryToEdit, string newName)
        //{
        //    int indexOfCat = categories.IndexOf(categoryToEdit);
        //    categories[indexOfCat] = newName;
        //    UpdateCategories(categories);
        //}

        //public List<string> GetCategories()
        //{
        //    categories.Clear();
        //    if (File.Exists(savedCategories))
        //    {
        //        using (StreamReader sr = new StreamReader(savedCategories))
        //        {
        //            string category = "";
        //            while (sr.ReadLine() != null)
        //            {
        //                category = sr.ReadLine();
        //                categories.Add(category);
        //            }
        //        }
        //    }
        //    return categories;
        //}

        //public void UpdateCategories(List<string> listOfCategories)
        //{
        //    File.WriteAllText(savedCategories, string.Empty);
        //    using (StreamWriter sw = File.AppendText(savedCategories))
        //    {
        //        foreach (var cat in listOfCategories)
        //        {
        //            sw.WriteLine(cat);
        //        }
        //    }
        //}
    }


}
