using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL.Exceptions;
using DAL;
using Models;
using BL;
using PodcastApp;
using System.Net.Configuration;

namespace BL
{
    public class Validation
    {
        private readonly DataManager dataManager = new DataManager();
        private readonly Urlhandler uH = new Urlhandler();
       


        public bool TboxCategoryNotEmpty(TextBox category)
        {
            bool isValid = false;
            try
            {
                if (category.Text != "")
                {
                    isValid = true;
                }
            }
            catch (TextBoxIsEmptyException e)
            {
                string msg = "You must enter a category in the textfield!";
                throw new TextBoxIsEmptyException(msg, e);
            }
            return isValid;
        }


        public bool CategoryIsPicked(ListBox listOfCategory)
        {
            bool isValid = false;
            try
            {
                if (listOfCategory.SelectedItem != null)
                {
                    isValid = true;
                }
            }
            catch (ItemNotPickedException e)
            {
                string msg = "You must pick a category!";
                throw new ItemNotPickedException(msg, e);    
            }
            return isValid;
        }

        public bool CategoryIsUnique(string category)
        {
            bool isValid = true;
            try
            {
                List<Category> list = dataManager.ReturnCategories();
                foreach (var item in list)
                {
                    string name = item.Name;

                    if (name.Equals(category))
                    {
                        isValid = false;
                        throw new ItemAlreadyExistsException();
                    }
                }
                
            }
            catch (ItemAlreadyExistsException)
            {
                string msg = "Category already exists!";
                MessageBox.Show(msg);
            }
            return isValid;
        }


        public bool IsCategoryListEmpty(List<string> catList)
        {
            bool notEmpty = false;
            try
            {
                if (catList.Count > 0)
                {
                    notEmpty = true;
                    throw new ListIsEmptyException();
                }
                
            }
            catch (ListIsEmptyException e)
            {
                string msg = "You don't have any categories!";
                throw new ListIsEmptyException(msg, e);
            }
            return notEmpty;
        }


        public bool TboxUrlNotEmpty(TextBox url)
        {
            bool isValid = false;
            try
            {
                if (url.Text != "")
                {
                    isValid = true;
                }
            }
            catch (TextBoxIsEmptyException e)
            {
                string msg = "You must enter a URL to proceed!";
                throw new TextBoxIsEmptyException(msg, e);
            }
            return isValid;
        }


        public bool ComboIntervalChoosen(ComboBox interval)
        {
            bool isValid = false;
            try
            {
                if (interval.SelectedItem != null)
                {
                    isValid = true;
                }
            }
            catch (ComboBoxIsNullException e)
            {
                string msg = "You must choose an interval!";
                throw new ComboBoxIsNullException(msg, e);
            }
            return isValid;
        }


        public bool ComboCategoryChoosen(ComboBox category)
        {
            bool isValid = false;
            try
            {
                if (category.SelectedItem != null)
                {
                    isValid = true;
                }
            }
            catch (ComboBoxIsNullException e)
            {
                string msg = "You must choose a category!";
                throw new ComboBoxIsNullException(msg, e);
            }
            return isValid;
        }


        public bool IsUrlValid(TextBox url)
        {
            bool isValid = false;
            try
            {
                foreach (var podcast in dataManager.ReturnPodcasts())
                {
                    if (podcast.Url != url.Text || uH.DoesUrlExist(url.Text) == false)
                    {
                        isValid = true;
                    }
                }
            }
            catch (ItemAlreadyExistsException e)
            {
                string msg = "Podcast already exists!";
                throw new ItemAlreadyExistsException(msg, e);
            }
            return isValid;
        }


        public bool CanPodcastBeDeleted(DataGridView table)
        {
            bool isValid = false;
            try
            {
                if (table.SelectedRows.Count > 0)
                {
                    isValid = true;
                }
            }
            catch (ItemNotPickedException e)
            {
                string msg = "You must choose a podcast to delete!";
                throw new ItemNotPickedException(msg, e);
            }
            return isValid;
        }



    }
}
