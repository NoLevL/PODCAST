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

namespace PodcastApp
{
    public partial class Form1 : Form
    {
        PodcastController podcastController;
        CategoryController categoryController;
        // private int podIndex = 0;
        public Form1()
        {
            InitializeComponent();
            podcastController = new PodcastController();
            categoryController = new CategoryController();
            //FormHandler metoder i Load-event istället för kontruktorn?
            FormHandler.FillCategoryList(categoryController.RetrieveAllCategories(), LstCat);
            FormHandler.FillCategoryComboBox(categoryController.RetrieveAllCategories(), CmbCat);
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

        }

        private void BtnNewPod_Click(object sender, EventArgs e)
        {
            PodcastController p = new PodcastController;
            p.CreatePodcastObject(TxtURL.Text,
                                                      CmbCat.SelectedItem.ToString(),
                                                      CmbUpdateFreq.SelectedItem.ToString());

            PodcastFeed.Rows.Add(p.TotalEpisodes, p.Name, p.Interval, p.Category);
            
        }

        private void BtnNewCat_Click(object sender, EventArgs e)
        {
            string addCategory = TxtCat.Text;
            categoryController.CreateCategoryObject(addCategory);
            FormHandler.FillCategoryList(categoryController.RetrieveAllCategories(), LstCat);
            FormHandler.FillCategoryComboBox(categoryController.RetrieveAllCategories(), CmbCat);
        }

        private void LstEpisodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPodcast = LstEpisodes.SelectedItem.ToString();
            LblPodEpi.Text = selectedPodcast;

            //List<Episode> episodeList = podcastController.GetEpisodeList(podIndex); //nåt som hittar index

            //foreach (var episode in episodeList)
            //{
            //    if (episode.EpisodeName.Equals(selectedPodcast))
            //    {
            //        string description = episode.EpisodeDescription;
            //        string removeText = @"<br/><br/>";
            //        TxtEpiInfo.Text = description.Replace(removeText + " ", "");
            //    }
            //}

        }

        private void BtnSaveCat_Click(object sender, EventArgs e)
        {
            int selectedCategory = LstCat.SelectedIndex;
            string updateCategory = TxtCat.Text;
            Category updateCategoryObject = new Category(updateCategory);
            categoryController.UpdateCategoryObject(selectedCategory, updateCategoryObject);
            FormHandler.FillCategoryList(categoryController.RetrieveAllCategories(), LstCat);
            FormHandler.FillCategoryComboBox(categoryController.RetrieveAllCategories(), CmbCat);
        }

        private void TxtCat_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
