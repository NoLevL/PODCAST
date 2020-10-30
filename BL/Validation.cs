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
                        throw new CategoryAlreadyExistsException();
                    }
                }
                
            }
            catch (CategoryAlreadyExistsException)
            {
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
                        throw new PodcastAlreadyExistsException();
                    }
                }
            }
            catch (PodcastAlreadyExistsException)
            {
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
                    throw new ComboBoxIntervalIsNullException();
                }
            }
            catch (ComboBoxIntervalIsNullException)
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
                    throw new ComboBoxCategoryIsNullException();
                }
            }
            catch (ComboBoxCategoryIsNullException)
            {
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
                    throw new CategoryNotPickedException();
                }
                else
                {
                    isSelected = true;
                }
            }
            catch
            {
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
                    throw new PodcastNotPickedException();
                }
            }
            catch (PodcastNotPickedException)
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
