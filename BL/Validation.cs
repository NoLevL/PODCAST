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
using System.IO;
using DAL.Repositories;

namespace BL
{
    public class Validation
    {
        private readonly Urlhandler uH = new Urlhandler();
        private readonly PodcastRepository podRepo = new PodcastRepository();
        private readonly CategoryRepository catRepo = new CategoryRepository();
       


        public bool TboxCategoryNotEmpty(TextBox category)
        {
            bool isValid = false;
            try
            {
                if (category.Text != "")
                {
                    isValid = true;
                }
                else
                {
                    throw new TextBoxIsEmptyException();
                }
            }
            catch (TextBoxIsEmptyException)
            {
                string msg = "You must enter a category in the textfield!";
                MessageBox.Show(msg);
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
                else
                {
                    throw new ItemNotPickedException();
                }
            }
            catch (ItemNotPickedException)
            {
                string msg = "You must pick a category!";
                MessageBox.Show(msg);
            }
            return isValid;
        }

        public bool CategoryIsUnique(string category)
        {
            bool isValid = true;
            try
            {
                List<Category> list = catRepo.GetAll();
                foreach (var item in list)
                {
                    string name = item.Name;

                    if (name.Equals(category))
                    {
                        isValid = false;
                        throw new ItemAlreadyExistsException();
                    }
                    //else
                    //{
                    //    throw new ItemAlreadyExistsException();
                    //}
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
                }
                else
                {
                    throw new ListIsEmptyException();
                }
                
            }
            catch (ListIsEmptyException)
            {
                string msg = "You don't have any categories!";
                MessageBox.Show(msg);
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
                else
                {
                    throw new TextBoxIsEmptyException();
                }
            }
            catch (TextBoxIsEmptyException)
            {
                string msg = "You must enter something in the textbox to proceed!";
                MessageBox.Show(msg);
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
                else
                {
                    throw new ComboBoxIsNullException();
                }
            }
            catch (ComboBoxIsNullException)
            {
                string msg = "You must choose an interval!";
                MessageBox.Show(msg);
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
                else
                {
                    throw new ComboBoxIsNullException();
                }
            }
            catch (ComboBoxIsNullException)
            {
                string msg = "You must choose a category!";
                MessageBox.Show(msg);
            }
            return isValid;
        }


        public bool IsUrlValid(TextBox url)
        {
            bool isValid = false;
            try
            {
                foreach (var podcast in podRepo.GetAll())
                {
                    if (podcast.Url != url.Text || uH.DoesUrlExist(url.Text) == false)
                    {
                        isValid = true;
                    }
                    else
                    {
                        throw new ItemAlreadyExistsException();
                    }
                }
            }
            catch (ItemAlreadyExistsException)
            {
                string msg = "Podcast already exists!";
                MessageBox.Show(msg);
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
                else
                {
                    throw new ItemNotPickedException();
                }
            }
            catch (ItemNotPickedException)
            {
                string msg = "You must choose a podcast to delete!";
                MessageBox.Show(msg);
            }
            return isValid;
        }

        public bool SavedCategoryFileExists()
        {
            string file = @"savedCategories.xml";
            bool fileExists = File.Exists(file);
            return fileExists;
        }

        public bool PodcastFileExists()
        {
            string file = @"Podcasts.xml";
            bool fileExists = File.Exists(file);
            return fileExists;
        }



    }
}
