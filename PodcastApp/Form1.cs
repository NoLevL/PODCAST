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

namespace PodcastApp
{
    public partial class Form1 : Form
    {
        PodcastController podcastController;
        public Form1()
        {
            InitializeComponent();
            podcastController = new PodcastController();
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

        private void BtnNewPod_Click(object sender, EventArgs e)
        {
            Podcast pod = await podcast
        }

        private void BtnNewCat_Click(object sender, EventArgs e)
        {
            string addCategory = TxtCat.Text;
            Category newCategory = new Category(addCategory);
        }
    }
}
