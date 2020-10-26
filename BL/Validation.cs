using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Models;

namespace BL
{
    public class Validation
    {
        private readonly DataManager dataManager = new DataManager();

        public bool TboxCategoryNotEmpty(TextBox category)
        {
            bool isValid = true;
            if(category.Text.Equals(""))
            {
                MessageBox.Show("You must enter a category to add/change it");
                //Throw new TextBoxIsEmptyException();
                isValid = false;
            }
            return isValid;
        }


        public bool CategoryIsPicked(ListBox listOfCategory)
        {
            bool isValid = true;
            if (listOfCategory.SelectedItem == null)
            {
                MessageBox.Show("You must pick a category!");
                //Throw new CategoryNotPickedException();
                isValid = false;
            }
            return isValid;
        }


        public bool CategoryIsUnique(TextBox category)
        {
            bool isValid = true;
            List<Category> list = dataManager.ReturnCategories();
            foreach (var item in list)
            {
                string name = item.Name;

                if (name.Equals(category.Text)) 
                {
                    MessageBox.Show("Category already exists!");
                    //Throw new CategoryAlreadyExistsException();
                    isValid = false;
                }
            }
            return isValid;
        }


        public bool IsCategoryListEmpty(List<string> catList)
        {
            bool notEmpty = true;
            if (catList.Count == 0)
            {
                MessageBox.Show("You don't have any categories!");
                //Throw new ListIsEmptyException();
                notEmpty = false;
            }
            return notEmpty;
        }


        public bool TboxUrlNotEmpty(TextBox url)
        {
            bool isValid = true;
            if (url.Text.Equals(""))
            {
                MessageBox.Show("You must enter a URL to proceed!");
                //Throw new TextBoxIsEmptyException();
                isValid = false;
            }
            return isValid;
        }


        public bool ComboIntervalChoosen(ComboBox interval)
        {
            bool isValid = true;
            if (interval.SelectedItem == null)
            {
                MessageBox.Show("You must choose an interval!");
                //Throw new ComboBoxIsNullException();
                isValid = false;
            }
            return isValid;
        }


        public bool ComboCategoryChoosen(ComboBox category)
        {
            bool isValid = true;
            if (category.SelectedItem == null)
            {
                MessageBox.Show("You must choose a category!");
                //Throw new ComboBoxIsNullException();
                isValid = false;
            }
            return isValid;
        }


        public bool IsUrlValid(TextBox url) //Behöver komplettering för att se om URL är legit eller ej
        {
            bool isValid = true;
            foreach (var podcast in dataManager.ReturnPodcasts())
            {
                if (podcast.Url.Equals(url.Text))
                {
                    MessageBox.Show("Podcast already exists!");
                    //Throw new PodcastAlreadyExistsException();
                    isValid = false;
                }
            }
            return isValid;
        }


        public bool CanPodcastBeDeleted(DataGridView table)
        {
            bool isValid = true;
            if (table.SelectedRows.Count == 0)
            {
                MessageBox.Show("You must choose a podcast to delete!");
                //Throw new PodcastNotPickedException();
                isValid = false;
            }
            return isValid;
        }



    }
}
