using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        PodcastController podcastController;
        CategoryController categoryController;
        //private int podIndex = 0;
        private Validation validator;
        Urlhandler handler;
        PodcastRepository podRepo;
        public Form1()
        {
            InitializeComponent();
            podcastController = new PodcastController();
            categoryController = new CategoryController();
            validator = new Validation();
            handler = new Urlhandler();
            podRepo = new PodcastRepository();
            
            //FormHandler metoder i Load-event istället för kontruktorn?
            FormHandler.FillCategoryList(categoryController.RetrieveAllCategories(), LstCat);
            FormHandler.FillCategoryComboBox(categoryController.RetrieveAllCategories(), CmbCat);
            FormHandler.FillIntervalComboBox(CmbUpdateFreq);
            FormHandler.AllPodcasts(PodcastFeed);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtURL_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LblPodEpi.Text = "";
            LstEpisodes.Items.Clear();

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
            //if (validator.TboxUrlNotEmpty(TxtURL) && validator.IsUrlValid(TxtURL) && validator.ComboIntervalChoosen(CmbUpdateFreq))
            //{
            Podcast p = new Podcast();
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
            //} 
            //else
            //{
            //    Podcast p = new Podcast();
            //    await Task.Run(() =>
            //    {
            //        podcastController.CreatePodcastObject(TxtURL.Text, CmbUpdateFreq.SelectedItem.ToString());

            //        PodcastFeed.Rows.Add(p.TotalEpisodes, p.Name, p.Interval, p.Category);
            //    });
            //}
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
            }
        }

        private void LstEpisodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPod = LstEpisodes.SelectedItem.ToString();
            LblPodEpiInfo.Text = selectedPod;

            List<Episode> episodeList = handler.GetEpisodes(TxtURL.Text);

            foreach (var item in episodeList)
            {
                if (item.EpisodeName.Equals(selectedPod))
                {
                    string description = item.EpisodeDescription;
                    string chars = @"<br/><br/>";
                    TxtEpiInfo.Text = description.Replace(chars + " ", "");
                }
            }
        }

        private void BtnSaveCat_Click(object sender, EventArgs e)
        {
            string updateCategory = TxtCat.Text;

            if (validator.CategoryIsUnique(updateCategory))
            {
                int selectedCategory = LstCat.SelectedIndex;
                Category updateCategoryObject = new Category(updateCategory);
                categoryController.UpdateCategoryObject(selectedCategory, updateCategoryObject);
                FormHandler.FillCategoryList(categoryController.RetrieveAllCategories(), LstCat);
                FormHandler.FillCategoryComboBox(categoryController.RetrieveAllCategories(), CmbCat);
                
            }
        }

        private void BtnDeleteCat_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to delete this category?\nAll podcasts of this category will be deleted";
            string header = "Delete category";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, header, buttons);
            if (result == DialogResult.Yes)
            {
                categoryController.DeleteCategory(LstCat.SelectedIndex);
                FormHandler.FillCategoryList(categoryController.RetrieveAllCategories(), LstCat);
                FormHandler.FillCategoryComboBox(categoryController.RetrieveAllCategories(), CmbCat);
                //Kod för att ta bort podcast som hör till vald kategori
            }
        }

        private void TxtCat_Click(object sender, EventArgs e)
        {
            TxtCat.Text = "";          
        }

        private double IntervalToDouble(ComboBox comboBox)
        {
            
            string lineToTrim = comboBox.SelectedItem.ToString();
            Console.WriteLine(lineToTrim);
            double interval = Double.Parse(lineToTrim.Remove(2));
            Console.WriteLine(interval);
            return interval;
        }
    }
}
