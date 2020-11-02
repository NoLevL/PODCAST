using System.Collections.Generic;
using System.Windows.Forms;
using BL;
using BL.Controllers;
using Models;


namespace PodcastApp
{
    public class FormHandler
    {

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
            comboBox.Items.Clear();
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
                List<Podcast> listToBeReturned = podcastController.RetrieveAllPodcasts();
                foreach (var item in listToBeReturned)
                {
                    podcastFeed.Rows.Add(item.TotalEpisodes, item.Name, item.Interval, item.Category);
                }
            }
        }

        public static void ClearEpisodeList(ListBox list)
        {
            list.Items.Clear();
        }

        public static void ClearEpisodeText(TextBox text)
        {
            text.Text = "";
        }

        public static void HideNewPodcastName(TextBox text, Button button)
        {
            text.Visible = false;
            button.Visible = false;
        }

        public static void ShowNewPodcastName(TextBox text, Button button)
        {
            text.Visible = true;
            button.Visible = true;
        }



    }
}
