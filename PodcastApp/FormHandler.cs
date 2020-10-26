using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace PodcastApp
{
    public class FormHandler
    {
        public static void ClearText(TextBox textBox)
        {
            textBox.Text = "";
        }

        public static void FillCategoryList(List<Category> list, ListBox listBox)
        {
            listBox.Items.Clear();
            foreach (var item in list)
            {
                listBox.Items.Add(item.Name);
            }
        }

        public static void FillCategoryComboBox(List<Category> list, ComboBox comboBox)
        {
            comboBox.Items.Clear();
            foreach (var item in list)
            {
                comboBox.Items.Add(item.Name);
            }
        }
    }
}
