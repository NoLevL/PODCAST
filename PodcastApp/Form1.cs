using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using BL.Controllers;
using BL;
using DAL.Repositories;
using System.Xml;
using System.ServiceModel.Syndication;

namespace PodcastApp
{
    public partial class Form1 : Form
    {
        private readonly PodcastController podcastController;
        private readonly CategoryController categoryController;
        private readonly PodcastRepository podRepo;
        private readonly Validation validator;
        private readonly Urlhandler handler;
        public Form1()
        {
            InitializeComponent();
            podcastController = new PodcastController();
            categoryController = new CategoryController();
            validator = new Validation();
            handler = new Urlhandler();
            podRepo = new PodcastRepository();

            FormHandler.FillCategoryComboBox(categoryController.RetrieveAllCategories(), CmbCat);
            FormHandler.FillIntervalComboBox(CmbUpdateFreq);
            ClearAndSet();

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LblPodEpi.Text = "";
            LstEpisodes.Items.Clear();

            FormHandler.ShowNewPodcastName(TxtNewPodName, BtnNewPodName);

            int selectedRow = PodcastFeed.CurrentCell.RowIndex;
           
            List<Episode> episodeList = podcastController.GetEpisodeList(selectedRow);
            foreach (var item in episodeList)
            {
                LstEpisodes.Items.Add(item.EpisodeName);
            }

            string url = podcastController.GetPodcastUrl(selectedRow);
            LblPodEpi.Text = handler.GetUrlName(url);
            TxtURL.Text = url;
            CmbCat.SelectedItem = podcastController.GetPodcastCategory(selectedRow);
            CmbUpdateFreq.SelectedItem = podcastController.GetPodcastInterval(selectedRow);


        }

        private async void BtnNewPod_Click(object sender, EventArgs e)
        {
            PodcastFeed.Rows.Clear();
            if (validator.TboxUrlNotEmpty(TxtURL) && validator.PodcastIsUnique(TxtURL.Text) && validator.ComboIntervalChoosen(CmbUpdateFreq) && validator.ComboCategoryChoosen(CmbCat))
            {

                string category = CmbCat.SelectedItem.ToString();
                double interval = IntervalToDouble(CmbUpdateFreq);

                SetInterval intervalObj = new SetInterval(interval);

                XmlReader reader = XmlReader.Create(TxtURL.Text);
                SyndicationFeed feed = SyndicationFeed.Load(reader);

                int numberOfEpisodes = 0;

                List<Episode> episodeList = new List<Episode>();
                string podcastName = feed.Title.Text;

                foreach (SyndicationItem item in feed.Items)
                {
                    numberOfEpisodes++;
                }
                foreach (SyndicationItem item in feed.Items)
                {
                    string episodeName = item.Title.Text;
                    string description = item.Summary.Text;
                    Episode anEpisode = new Episode(episodeName, description);
                    episodeList.Add(anEpisode);

                }
                await Task.Run(() =>
                {
                    podcastController.CreatePodcastObject(TxtURL.Text, intervalObj.UpdateInterval, category, podcastName, numberOfEpisodes, episodeList);
                });
                FormHandler.AllPodcasts(PodcastFeed);
                FormHandler.HideNewPodcastName(TxtNewPodName, BtnNewPodName);
            
            }
            else
            {
                ClearAndSet();
            }
        }

        private void BtnNewCat_Click(object sender, EventArgs e)
        {
            string addCategory = TxtCat.Text;
            if (!validator.SavedCategoryFileExists())
            {
                categoryController.CreateCategoryObject(addCategory);
                FormHandler.FillCategoryList(categoryController.RetrieveAllCategories(), LstCat);
                FormHandler.FillCategoryComboBox(categoryController.RetrieveAllCategories(), CmbCat);
            }
            else if (validator.CategoryIsUnique(addCategory))
            {
                categoryController.CreateCategoryObject(addCategory);
                FormHandler.FillCategoryList(categoryController.RetrieveAllCategories(), LstCat);
                FormHandler.FillCategoryComboBox(categoryController.RetrieveAllCategories(), CmbCat);
                FormHandler.HideNewPodcastName(TxtNewPodName, BtnNewPodName);
            }
        }

        private void LstEpisodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormHandler.HideNewPodcastName(TxtNewPodName, BtnNewPodName);
            string selectedPod = LstEpisodes.SelectedItem.ToString();
            LblPodEpiInfo.Text = selectedPod;

            List<Episode> episodeList = handler.GetEpisodes(TxtURL.Text);

            foreach (var item in episodeList)
            {
                if (item.EpisodeName.Equals(selectedPod) && LstEpisodes.SelectedItem.ToString().Equals(item.EpisodeName))
                {
                    string description = item.EpisodeDescription;
                    string chars = @"<br/><br/>";
                    TxtEpiInfo.Text = description.Replace(chars + " ", "");
                    string pubDate = handler.GetDateInfo(TxtURL.Text, item);
                    LblDate.Text = pubDate.Remove(10);
                }
            }
        }

        private void BtnSaveCat_Click(object sender, EventArgs e)
        {
            FormHandler.HideNewPodcastName(TxtNewPodName, BtnNewPodName);
            string updateCategory = TxtCat.Text;

            if (validator.CategoryIsUnique(updateCategory))
            {
                string oldCategory = LstCat.SelectedItem.ToString();
                int selectedCategory = LstCat.SelectedIndex;
                Category updateCategoryObject = new Category(updateCategory);
                categoryController.UpdateCategoryObject(selectedCategory, oldCategory, updateCategoryObject);
                ClearAndSet();
            }
        }

        private void BtnDeleteCat_Click(object sender, EventArgs e)
        {
            FormHandler.HideNewPodcastName(TxtNewPodName, BtnNewPodName);
            string message = "Are you sure you want to delete this category?\nAll podcasts of this category will be deleted";
            string header = "Delete category";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, header, buttons);
            if (result == DialogResult.Yes)
            {
                string category = LstCat.SelectedItem.ToString();
                var podList = podcastController.RetrieveAllPodcasts();
                foreach (var item in podList)
                {
                    if (item.Category.Equals(category))
                    {
                        podcastController.DeletePodcast(category);
                        
                    }
                }
                categoryController.DeleteCategory(LstCat.SelectedIndex);
                ClearAndSet();
            }
        }

        private void TxtCat_Click(object sender, EventArgs e)
        {
            FormHandler.HideNewPodcastName(TxtNewPodName, BtnNewPodName);
            TxtCat.Text = "";
        }

        private double IntervalToDouble(ComboBox comboBox)
        {
            
            string lineToTrim = comboBox.SelectedItem.ToString();
            double interval = Double.Parse(lineToTrim.Remove(2));
            return interval;
        }

        private void BtnDeletePod_Click(object sender, EventArgs e)
        {
            if (validator.CanPodcastBeDeleted(PodcastFeed))
            {
                FormHandler.HideNewPodcastName(TxtNewPodName, BtnNewPodName);
                string message = "Are you sure you want to delete this Podcast?";
                string header = "Delete Podcast";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, header, buttons);
                if (result == DialogResult.Yes)
                {
                    podcastController.DeletePodcast(PodcastFeed.CurrentCell.RowIndex);
                    ClearAndSet();
                }
            }
        }

        private void ClearAndSet()
        {
            PodcastFeed.Rows.Clear();
            FormHandler.ClearEpisodeList(LstEpisodes);
            FormHandler.ClearEpisodeText(TxtEpiInfo);
            FormHandler.FillCategoryList(categoryController.RetrieveAllCategories(), LstCat);
            LblPodEpi.Text = "Episodes";
            LblPodEpiInfo.Text = "Episode description";
            TxtURL.Text = "";
            CmbCat.Text = "";
            CmbUpdateFreq.Text = "";
            LblDate.Text = "";
            FormHandler.AllPodcasts(PodcastFeed);
        }

        private void BtnNewPodName_Click(object sender, EventArgs e)
        {
            if (validator.TboxUrlNotEmpty(TxtNewPodName))
            {
                int selectedRow = PodcastFeed.CurrentCell.RowIndex;
                podcastController.UpdatePodcastName(selectedRow, TxtNewPodName.Text);
                ClearAndSet();
                FormHandler.HideNewPodcastName(TxtNewPodName, BtnNewPodName);
            }
        }

        private void BtnSavePod_Click(object sender, EventArgs e)
        {
            if (validator.ComboIntervalChoosen(CmbUpdateFreq) && validator.ComboCategoryChoosen(CmbCat))
            {
                int podToUpdate = PodcastFeed.CurrentCell.RowIndex;
                string category = CmbCat.SelectedItem.ToString();
                double interval = IntervalToDouble(CmbUpdateFreq);
                podcastController.UpdatePodcast(podToUpdate, category, interval);
                ClearAndSet();
                FormHandler.HideNewPodcastName(TxtNewPodName, BtnNewPodName);
            }
        }

        private void TxtURL_Click(object sender, EventArgs e)
        {
            TxtURL.Text = "";
        }

        private void BtnSortPodByCat_Click(object sender, EventArgs e)
        {
            if (validator.CategorySelected(LstCat))
            {
                string category = LstCat.SelectedItem.ToString();
                var podList = podcastController.RetrieveAllPodcasts();
                ClearAndSet();
                if (PodcastFeed.Rows.Count > 0)
                {
                    foreach (var pod in podList)
                    {
                        if (pod.Category != category)
                        {
                            string name = pod.Name;
                            int index = podRepo.GetIndex(name);
                            PodcastFeed.Rows[index].Visible = false;
                        }
                    }
                }
            }
            
        }

        private void BtnListAllPodcasts_Click(object sender, EventArgs e)
        {
            ClearAndSet();
        }
    }
}
