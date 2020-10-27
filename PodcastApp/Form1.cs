﻿using System;
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
        private int podIndex = 0;
        private Validation validator;
        public Form1()
        {
            InitializeComponent();
            podcastController = new PodcastController();
            categoryController = new CategoryController();
            validator = new Validation();
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
            TxtURL.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async Task<Podcast> BtnNewPod_Click(object sender, EventArgs e)
        {
           
            Podcast p = new Podcast();
            await Task.Run(() =>
            {
                podcastController.CreatePodcastObject(TxtURL.Text, CmbCat.SelectedItem.ToString(), CmbUpdateFreq.SelectedItem.ToString());

                PodcastFeed.Rows.Add(p.TotalEpisodes, p.Name, p.Interval, p.Category);
            });
            return p;
            
        }

        private void BtnNewCat_Click(object sender, EventArgs e)
        {
            string addCategory = TxtCat.Text;
            if (validator.CategoryIsUnique(addCategory))
            {
                categoryController.CreateCategoryObject(addCategory);
                FormHandler.FillCategoryList(categoryController.RetrieveAllCategories(), LstCat);
                FormHandler.FillCategoryComboBox(categoryController.RetrieveAllCategories(), CmbCat);
            }
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
            if (result == System.Windows.Forms.DialogResult.Yes)
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
    }
}
