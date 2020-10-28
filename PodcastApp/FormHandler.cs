using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using BL.Controllers;
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

        public static void FillIntervalComboBox(ComboBox comboBox)
        {
            comboBox.Items.Add("15 min");
            comboBox.Items.Add("30 min");
            comboBox.Items.Add("60 min");
        }

        public static void AllPodcasts(DataGridView podcastFeed)
        {
            Validation validator = new Validation();
            if (validator.PodcastFileExists())
            {
                PodcastController podcastController = new PodcastController();
                List<Podcast> listToBeReturned = new List<Podcast>();
                listToBeReturned = podcastController.RetrieveAllPodcasts();
                foreach (var item in listToBeReturned)
                {
                    podcastFeed.Rows.Add(item.TotalEpisodes, item.Name, item.Interval, item.Category);
                }
            }
        }


    }
}
