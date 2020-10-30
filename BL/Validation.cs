using System.Collections.Generic;
using System.Windows.Forms;
using BL.Exceptions;
using Models;
using System.IO;
using DAL.Repositories;

namespace BL
{
    public class Validation
    {
        private readonly PodcastRepository podRepo = new PodcastRepository();
        private readonly CategoryRepository catRepo = new CategoryRepository();
       

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
                }
                
            }
            catch (ItemAlreadyExistsException)
            {
                string msg = "Category already exists!";
                MessageBox.Show(msg);
            }
            return isValid;
        }

        public bool PodcastIsUnique(string url)
        {
            bool isValid = true;
            try
            {
                List<Podcast> list = podRepo.GetAll();
                foreach (var item in list)
                {
                    string link = item.Url;

                    if(link.Equals(url))
                    {
                        isValid = false;
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
            string freq = "interval menu!";
            bool isValid = false;
            try
            {
                if (interval.SelectedItem != null)
                {
                    isValid = true;
                }
                else
                {
                    throw new ComboBoxIsNullException(freq);
                }
            }
            catch (ComboBoxIsNullException)
            {
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


        public bool CategorySelected(ListBox list)
        {
            bool isSelected = false;
            try
            {
                if (list.SelectedItem == null)
                {
                    throw new ItemNotPickedException();
                }
                else
                {
                    isSelected = true;
                }
            }
            catch
            {
                string msg = "You must select a category first!";
                MessageBox.Show(msg);
            }
            return isSelected;
        }


        public bool CanPodcastBeDeleted(DataGridView table)
        {
            bool isValid = false;
            try
            {
                if (table.CurrentCell.RowIndex > -1)
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
