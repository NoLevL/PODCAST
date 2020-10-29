namespace PodcastApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing); 
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnNewPod = new System.Windows.Forms.Button();
            this.BtnSavePod = new System.Windows.Forms.Button();
            this.BtnDeletePod = new System.Windows.Forms.Button();
            this.BtnSaveCat = new System.Windows.Forms.Button();
            this.BtnNewCat = new System.Windows.Forms.Button();
            this.BtnDeleteCat = new System.Windows.Forms.Button();
            this.CmbUpdateFreq = new System.Windows.Forms.ComboBox();
            this.CmbCat = new System.Windows.Forms.ComboBox();
            this.lblCat = new System.Windows.Forms.Label();
            this.lblUpdateFreq = new System.Windows.Forms.Label();
            this.lblURL = new System.Windows.Forms.Label();
            this.TxtCat = new System.Windows.Forms.TextBox();
            this.LstEpisodes = new System.Windows.Forms.ListBox();
            this.LstCat = new System.Windows.Forms.ListBox();
            this.lblCats = new System.Windows.Forms.Label();
            this.LblPodEpi = new System.Windows.Forms.Label();
            this.LblPodEpiInfo = new System.Windows.Forms.Label();
            this.TxtURL = new System.Windows.Forms.TextBox();
            this.TxtEpiInfo = new System.Windows.Forms.TextBox();
            this.PodcastFeed = new System.Windows.Forms.DataGridView();
            this.ColumnEpisode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFreq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.PodcastFeed)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnNewPod
            // 
            this.BtnNewPod.Location = new System.Drawing.Point(87, 220);
            this.BtnNewPod.Margin = new System.Windows.Forms.Padding(2);
            this.BtnNewPod.Name = "BtnNewPod";
            this.BtnNewPod.Size = new System.Drawing.Size(101, 23);
            this.BtnNewPod.TabIndex = 0;
            this.BtnNewPod.Text = "New...";
            this.BtnNewPod.UseVisualStyleBackColor = true;
            this.BtnNewPod.Click += new System.EventHandler(this.BtnNewPod_Click);
            // 
            // BtnSavePod
            // 
            this.BtnSavePod.Location = new System.Drawing.Point(191, 220);
            this.BtnSavePod.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSavePod.Name = "BtnSavePod";
            this.BtnSavePod.Size = new System.Drawing.Size(101, 23);
            this.BtnSavePod.TabIndex = 1;
            this.BtnSavePod.Text = "Save";
            this.BtnSavePod.UseVisualStyleBackColor = true;
            // 
            // BtnDeletePod
            // 
            this.BtnDeletePod.Location = new System.Drawing.Point(296, 220);
            this.BtnDeletePod.Margin = new System.Windows.Forms.Padding(2);
            this.BtnDeletePod.Name = "BtnDeletePod";
            this.BtnDeletePod.Size = new System.Drawing.Size(101, 23);
            this.BtnDeletePod.TabIndex = 2;
            this.BtnDeletePod.Text = "Delete...";
            this.BtnDeletePod.UseVisualStyleBackColor = true;
            this.BtnDeletePod.Click += new System.EventHandler(this.BtnDeletePod_Click);
            // 
            // BtnSaveCat
            // 
            this.BtnSaveCat.Location = new System.Drawing.Point(592, 203);
            this.BtnSaveCat.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSaveCat.Name = "BtnSaveCat";
            this.BtnSaveCat.Size = new System.Drawing.Size(101, 23);
            this.BtnSaveCat.TabIndex = 3;
            this.BtnSaveCat.Text = "Save";
            this.BtnSaveCat.UseVisualStyleBackColor = true;
            this.BtnSaveCat.Click += new System.EventHandler(this.BtnSaveCat_Click);
            // 
            // BtnNewCat
            // 
            this.BtnNewCat.Location = new System.Drawing.Point(463, 203);
            this.BtnNewCat.Margin = new System.Windows.Forms.Padding(2);
            this.BtnNewCat.Name = "BtnNewCat";
            this.BtnNewCat.Size = new System.Drawing.Size(101, 23);
            this.BtnNewCat.TabIndex = 4;
            this.BtnNewCat.Text = "Add";
            this.BtnNewCat.UseVisualStyleBackColor = true;
            this.BtnNewCat.Click += new System.EventHandler(this.BtnNewCat_Click);
            // 
            // BtnDeleteCat
            // 
            this.BtnDeleteCat.Location = new System.Drawing.Point(719, 203);
            this.BtnDeleteCat.Margin = new System.Windows.Forms.Padding(2);
            this.BtnDeleteCat.Name = "BtnDeleteCat";
            this.BtnDeleteCat.Size = new System.Drawing.Size(101, 23);
            this.BtnDeleteCat.TabIndex = 5;
            this.BtnDeleteCat.Text = "Delete...";
            this.BtnDeleteCat.UseVisualStyleBackColor = true;
            this.BtnDeleteCat.Click += new System.EventHandler(this.BtnDeleteCat_Click);
            // 
            // CmbUpdateFreq
            // 
            this.CmbUpdateFreq.FormattingEnabled = true;
            this.CmbUpdateFreq.Location = new System.Drawing.Point(159, 186);
            this.CmbUpdateFreq.Margin = new System.Windows.Forms.Padding(2);
            this.CmbUpdateFreq.Name = "CmbUpdateFreq";
            this.CmbUpdateFreq.Size = new System.Drawing.Size(107, 21);
            this.CmbUpdateFreq.TabIndex = 7;
            // 
            // CmbCat
            // 
            this.CmbCat.FormattingEnabled = true;
            this.CmbCat.Location = new System.Drawing.Point(291, 186);
            this.CmbCat.Margin = new System.Windows.Forms.Padding(2);
            this.CmbCat.Name = "CmbCat";
            this.CmbCat.Size = new System.Drawing.Size(107, 21);
            this.CmbCat.TabIndex = 8;
            // 
            // lblCat
            // 
            this.lblCat.AutoSize = true;
            this.lblCat.Location = new System.Drawing.Point(291, 168);
            this.lblCat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCat.Name = "lblCat";
            this.lblCat.Size = new System.Drawing.Size(52, 13);
            this.lblCat.TabIndex = 9;
            this.lblCat.Text = "Category:";
            this.lblCat.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblUpdateFreq
            // 
            this.lblUpdateFreq.AutoSize = true;
            this.lblUpdateFreq.Location = new System.Drawing.Point(156, 168);
            this.lblUpdateFreq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUpdateFreq.Name = "lblUpdateFreq";
            this.lblUpdateFreq.Size = new System.Drawing.Size(92, 13);
            this.lblUpdateFreq.TabIndex = 10;
            this.lblUpdateFreq.Text = "Updatefrequency:";
            // 
            // lblURL
            // 
            this.lblURL.AutoSize = true;
            this.lblURL.Location = new System.Drawing.Point(5, 168);
            this.lblURL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(32, 13);
            this.lblURL.TabIndex = 12;
            this.lblURL.Text = "URL:";
            // 
            // TxtCat
            // 
            this.TxtCat.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TxtCat.Location = new System.Drawing.Point(463, 174);
            this.TxtCat.Margin = new System.Windows.Forms.Padding(2);
            this.TxtCat.Name = "TxtCat";
            this.TxtCat.Size = new System.Drawing.Size(357, 20);
            this.TxtCat.TabIndex = 13;
            this.TxtCat.Text = "Search for category...";
            this.TxtCat.Click += new System.EventHandler(this.TxtCat_Click);
            // 
            // LstEpisodes
            // 
            this.LstEpisodes.FormattingEnabled = true;
            this.LstEpisodes.Location = new System.Drawing.Point(11, 290);
            this.LstEpisodes.Margin = new System.Windows.Forms.Padding(2);
            this.LstEpisodes.Name = "LstEpisodes";
            this.LstEpisodes.Size = new System.Drawing.Size(387, 147);
            this.LstEpisodes.TabIndex = 15;
            this.LstEpisodes.SelectedIndexChanged += new System.EventHandler(this.LstEpisodes_SelectedIndexChanged);
            // 
            // LstCat
            // 
            this.LstCat.FormattingEnabled = true;
            this.LstCat.Location = new System.Drawing.Point(463, 24);
            this.LstCat.Margin = new System.Windows.Forms.Padding(2);
            this.LstCat.Name = "LstCat";
            this.LstCat.Size = new System.Drawing.Size(357, 134);
            this.LstCat.TabIndex = 16;
            // 
            // lblCats
            // 
            this.lblCats.AutoSize = true;
            this.lblCats.Location = new System.Drawing.Point(461, 9);
            this.lblCats.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCats.Name = "lblCats";
            this.lblCats.Size = new System.Drawing.Size(60, 13);
            this.lblCats.TabIndex = 17;
            this.lblCats.Text = "Categories:";
            // 
            // LblPodEpi
            // 
            this.LblPodEpi.AutoSize = true;
            this.LblPodEpi.Location = new System.Drawing.Point(8, 275);
            this.LblPodEpi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblPodEpi.Name = "LblPodEpi";
            this.LblPodEpi.Size = new System.Drawing.Size(50, 13);
            this.LblPodEpi.TabIndex = 18;
            this.LblPodEpi.Text = "Episodes";
            // 
            // LblPodEpiInfo
            // 
            this.LblPodEpiInfo.AutoSize = true;
            this.LblPodEpiInfo.Location = new System.Drawing.Point(461, 254);
            this.LblPodEpiInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LblPodEpiInfo.Name = "LblPodEpiInfo";
            this.LblPodEpiInfo.Size = new System.Drawing.Size(99, 13);
            this.LblPodEpiInfo.TabIndex = 19;
            this.LblPodEpiInfo.Text = "Episode description";
            // 
            // TxtURL
            // 
            this.TxtURL.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TxtURL.Location = new System.Drawing.Point(8, 186);
            this.TxtURL.Margin = new System.Windows.Forms.Padding(2);
            this.TxtURL.Name = "TxtURL";
            this.TxtURL.Size = new System.Drawing.Size(147, 20);
            this.TxtURL.TabIndex = 21;
            this.TxtURL.Text = "Enter URL here...";
            this.TxtURL.TextChanged += new System.EventHandler(this.txtURL_TextChanged);
            // 
            // TxtEpiInfo
            // 
            this.TxtEpiInfo.Location = new System.Drawing.Point(463, 270);
            this.TxtEpiInfo.Multiline = true;
            this.TxtEpiInfo.Name = "TxtEpiInfo";
            this.TxtEpiInfo.ReadOnly = true;
            this.TxtEpiInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtEpiInfo.Size = new System.Drawing.Size(352, 167);
            this.TxtEpiInfo.TabIndex = 22;
            // 
            // PodcastFeed
            // 
            this.PodcastFeed.AllowUserToAddRows = false;
            this.PodcastFeed.AllowUserToDeleteRows = false;
            this.PodcastFeed.AllowUserToResizeColumns = false;
            this.PodcastFeed.AllowUserToResizeRows = false;
            this.PodcastFeed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PodcastFeed.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PodcastFeed.BackgroundColor = System.Drawing.SystemColors.Window;
            this.PodcastFeed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PodcastFeed.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnEpisode,
            this.ColumnName,
            this.ColumnFreq,
            this.ColumnCat});
            this.PodcastFeed.Location = new System.Drawing.Point(10, 24);
            this.PodcastFeed.MultiSelect = false;
            this.PodcastFeed.Name = "PodcastFeed";
            this.PodcastFeed.ReadOnly = true;
            this.PodcastFeed.RowHeadersVisible = false;
            this.PodcastFeed.RowHeadersWidth = 10;
            this.PodcastFeed.Size = new System.Drawing.Size(387, 137);
            this.PodcastFeed.TabIndex = 23;
            this.PodcastFeed.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ColumnEpisode
            // 
            this.ColumnEpisode.HeaderText = "Episodes";
            this.ColumnEpisode.MinimumWidth = 4;
            this.ColumnEpisode.Name = "ColumnEpisode";
            this.ColumnEpisode.ReadOnly = true;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // ColumnFreq
            // 
            this.ColumnFreq.HeaderText = "Frequency";
            this.ColumnFreq.Name = "ColumnFreq";
            this.ColumnFreq.ReadOnly = true;
            // 
            // ColumnCat
            // 
            this.ColumnCat.HeaderText = "Category";
            this.ColumnCat.Name = "ColumnCat";
            this.ColumnCat.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 443);
            this.Controls.Add(this.PodcastFeed);
            this.Controls.Add(this.TxtEpiInfo);
            this.Controls.Add(this.TxtURL);
            this.Controls.Add(this.LblPodEpiInfo);
            this.Controls.Add(this.LblPodEpi);
            this.Controls.Add(this.lblCats);
            this.Controls.Add(this.LstCat);
            this.Controls.Add(this.LstEpisodes);
            this.Controls.Add(this.TxtCat);
            this.Controls.Add(this.lblURL);
            this.Controls.Add(this.lblUpdateFreq);
            this.Controls.Add(this.lblCat);
            this.Controls.Add(this.CmbCat);
            this.Controls.Add(this.CmbUpdateFreq);
            this.Controls.Add(this.BtnDeleteCat);
            this.Controls.Add(this.BtnNewCat);
            this.Controls.Add(this.BtnSaveCat);
            this.Controls.Add(this.BtnDeletePod);
            this.Controls.Add(this.BtnSavePod);
            this.Controls.Add(this.BtnNewPod);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PodcastFeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnNewPod;
        private System.Windows.Forms.Button BtnSavePod;
        private System.Windows.Forms.Button BtnDeletePod;
        private System.Windows.Forms.Button BtnSaveCat;
        private System.Windows.Forms.Button BtnNewCat;
        private System.Windows.Forms.Button BtnDeleteCat;
        private System.Windows.Forms.ComboBox CmbUpdateFreq;
        private System.Windows.Forms.ComboBox CmbCat;
        private System.Windows.Forms.Label lblCat;
        private System.Windows.Forms.Label lblUpdateFreq;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.TextBox TxtCat;
        private System.Windows.Forms.ListBox LstEpisodes;
        private System.Windows.Forms.ListBox LstCat;
        private System.Windows.Forms.Label lblCats;
        private System.Windows.Forms.Label LblPodEpi;
        private System.Windows.Forms.Label LblPodEpiInfo;
        private System.Windows.Forms.TextBox TxtURL;
        private System.Windows.Forms.TextBox TxtEpiInfo;
        private System.Windows.Forms.DataGridView PodcastFeed;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEpisode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFreq;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCat;
    }
}

