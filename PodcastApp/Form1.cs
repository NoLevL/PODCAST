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
            SetTimerWhenPageOpens();

            
            FormHandler.FillIntervalComboBox(CmbUpdateFreq);
            ClearAndSet();

        }

        //Lists all episodes from the selected podcast
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
            LblPodEpi.Text = handler.GetPodcastName(url);
            TxtURL.Text = url;
            CmbCat.SelectedItem = podcastController.GetPodcastCategory(selectedRow);
            CmbUpdateFreq.SelectedItem = podcastController.GetPodcastInterval(selectedRow);


        }

        //Adds a new podcast
        private async void BtnNewPod_Click(object sender, EventArgs e)
        {
            PodcastFeed.Rows.Clear();
            if (validator.TboxUrlNotEmpty(TxtURL) && validator.PodcastIsUnique(TxtURL.Text) && validator.ComboIntervalChoosen(CmbUpdateFreq) && validator.ComboCategoryChoosen(CmbCat))
            {

                string category = CmbCat.SelectedItem.ToString();
                double interval = IntervalToDouble(CmbUpdateFreq);

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
                    podcastController.CreatePodcastObject(TxtURL.Text, interval, category, podcastName, numberOfEpisodes, episodeList);
                    SetTimer(interval);
                });
                ClearAndSet();
                FormHandler.HideNewPodcastName(TxtNewPodName, BtnNewPodName);
            
            }
            else
            {
                ClearAndSet();
            }
        }

        //Adds a new cateogry
        private void BtnNewCat_Click(object sender, EventArgs e)
        {
            string addCategory = TxtCat.Text;
            if (!validator.SavedCategoryFileExists())
            {
                categoryController.CreateCategoryObject(addCategory);
                FormHandler.FillCategoryList(categoryController.RetrieveAllCategories(), LstCat);
                FormHandler.FillCategoryComboBox(categoryController.RetrieveAllCategories(), CmbCat);
                TxtCat.Text = "";
            }
            else if (validator.CategoryIsUnique(addCategory))
            {
                categoryController.CreateCategoryObject(addCategory);
                FormHandler.FillCategoryList(categoryController.RetrieveAllCategories(), LstCat);
                FormHandler.FillCategoryComboBox(categoryController.RetrieveAllCategories(), CmbCat);
                FormHandler.HideNewPodcastName(TxtNewPodName, BtnNewPodName);
                TxtCat.Text = "";
            }
        }

        //Displays the description of an episode when it's clicked
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

        //Changes the name of a category
        private void BtnSaveCat_Click(object sender, EventArgs e)
        {
            FormHandler.HideNewPodcastName(TxtNewPodName, BtnNewPodName);
            string updateCategory = TxtCat.Text;

            if (validator.CategoryIsUnique(updateCategory) && validator.CategorySelected(LstCat))
            {
                string oldCategory = LstCat.SelectedItem.ToString();
                int selectedCategory = LstCat.SelectedIndex;
                Category updateCategoryObject = new Category(updateCategory);
                categoryController.UpdateCategoryObject(selectedCategory, oldCategory, updateCategoryObject);
                ClearAndSet();
            }
        }

        //Deletes a category
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
                        //If the deleted category has any podcasts they are deleted
                        podcastController.DeletePodcast(category);
                        
                    }
                }
                categoryController.DeleteCategory(LstCat.SelectedIndex);
                ClearAndSet();
            }
        }

        //Clears a textbox when it's clicked
        private void TxtCat_Click(object sender, EventArgs e)
        {
            FormHandler.HideNewPodcastName(TxtNewPodName, BtnNewPodName);
            TxtCat.Text = "";
        }

        //Converts a string value in a combobox to double
        private double IntervalToDouble(ComboBox comboBox)
        {
            
            string lineToTrim = comboBox.SelectedItem.ToString();
            double interval = Double.Parse(lineToTrim.Remove(2));
            return interval;
        }

        //Deletes a podcast
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

        //Clears and updates boxes in the form
        private void ClearAndSet()
        {
            PodcastFeed.Rows.Clear();
            FormHandler.ClearEpisodeList(LstEpisodes);
            FormHandler.ClearEpisodeText(TxtEpiInfo);
            FormHandler.FillCategoryList(categoryController.RetrieveAllCategories(), LstCat);
            FormHandler.FillCategoryComboBox(categoryController.RetrieveAllCategories(), CmbCat);
            LblPodEpi.Text = "Episodes";
            LblPodEpiInfo.Text = "Episode description";
            TxtURL.Text = "";
            CmbCat.Text = "";
            CmbUpdateFreq.Text = "";
            LblDate.Text = "";
            FormHandler.AllPodcasts(PodcastFeed);
            FormHandler.FillCategoryComboBox(categoryController.RetrieveAllCategories(), CmbCat);
        }

        //Changes the name of a selected podcast
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

        //Changes the interval time and category of a selected podcast
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

        //Clears text when the textbox is clicked
        private void TxtURL_Click(object sender, EventArgs e)
        {
            TxtURL.Text = "";
        }

        //Displays the podcasts based on what category is selected
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
                        else
                        {
                            string name = pod.Name;
                            int index = podRepo.GetIndex(name);
                            PodcastFeed.Rows[index].Visible = true;
                        }
                    }
                }
            }
            
        }

        //Displays all podcasts
        private void BtnListAllPodcasts_Click(object sender, EventArgs e)
        {
            ClearAndSet();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            ClearAndSet();
        }

        public void SetTimer(double interval)
        {
            int chosenInterval;

            if (interval == 15)
            {
                chosenInterval = 900000;
                CreateTimer(chosenInterval);

            }
            if (interval == 30)
            {
                chosenInterval = 1800000;
                CreateTimer(chosenInterval);
            }
            else if (interval == 60)
            {
                chosenInterval = 3600000;
                CreateTimer(chosenInterval);
            }
        }

        public void SetTimerWhenPageOpens()
        {
            int nextUpdate;
            List<Podcast> podcastList = podcastController.RetrieveAllPodcasts();

            foreach (var p in podcastList)
            {
                double pInterval = p.Interval;
                string eachUrl = p.Url;

                if (pInterval == 15)
                {
                    nextUpdate = 900000;
                    CreateTimer(nextUpdate);
                }
                if (pInterval == 30)
                {
                    nextUpdate = 1800000;
                    CreateTimer(nextUpdate);
                }
                else if (pInterval == 60)
                {
                    nextUpdate = 3600000;
                    CreateTimer(nextUpdate);
                }
            }
        }

        public void CreateTimer(int interval)
        {
            var timer = new Timer
            {
                Interval = interval,
                Enabled = true,
                Tag = TxtURL.Text
            };
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
        }
    }
}
