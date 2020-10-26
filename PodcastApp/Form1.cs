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
        // private int podIndex = 0;
        CategoryController categoryController;
        Validation validation;
        
        public Form1()
        {
            InitializeComponent();
            podcastController = new PodcastController();
            categoryController = new CategoryController();
            validation = new Validation();
            
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
            if (validation.TboxUrlNotEmpty(TxtURL))
            {
                if (validation.CategoryIsPicked(LstCat))
                {
                    Podcast p = new Podcast();
                    Podcast p  podcastController.CreatePodcastObject(TxtURL.Text, CmbUpdateFreq.SelectedItem.ToString(), LstCat.SelectedItem.ToString());
                    PodcastFeed.Rows.Add(p.TotalEpisodes, p.Name, p.Interval, p.Category); //wtf
                }
            }
        }

        private void BtnNewCat_Click(object sender, EventArgs e)
        {
            string addCategory = TxtCat.Text;
            Category newCategory = new Category(addCategory);
        }

        private void LstEpisodes_SelectedIndexChanged(object sender, EventArgs e)
        { 
        }

        private void TxtCat_TextChanged(object sender, EventArgs e)
        {

        }
        //{
        //    string selectedPodcast = LstEpisodes.SelectedItem.ToString();
        //    LblPodEpi.Text = selectedPodcast;

        //    List<Episode> episodeList = podcastController.GetEpisodeList(podIndex); //nåt som hittar index

        //    foreach (var episode in episodeList)
        //    {
        //        if (episode.EpisodeName.Equals(selectedPodcast))
        //        {
        //            string description = episode.EpisodeDescription;
        //            string removeText = @"<br/><br/>";
        //            TxtEpiInfo.Text = description.Replace(removeText + " ", "");
        //        }
        //    }

        //}
    }
}
