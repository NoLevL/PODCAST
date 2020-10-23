using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Models
{
    public class Category : DataManager
    {
        
        public void AddCategory(string category)
        {
            categories.Add(category);
            using (StreamWriter sw = File.AppendText(savedCategories))
            {
                sw.WriteLine(category);
            }
        }
    }

    public void UpdateCategories (List<string> listOfCategories)
    {

    }
}
