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
            this.btnNewPod = new System.Windows.Forms.Button();
            this.btnSavePod = new System.Windows.Forms.Button();
            this.btnDeletePod = new System.Windows.Forms.Button();
            this.btnSaveCat = new System.Windows.Forms.Button();
            this.btnNewCat = new System.Windows.Forms.Button();
            this.btnDeleteCat = new System.Windows.Forms.Button();
            this.cmbUpdateFreq = new System.Windows.Forms.ComboBox();
            this.cmbCat = new System.Windows.Forms.ComboBox();
            this.lblCat = new System.Windows.Forms.Label();
            this.lblUpdateFreq = new System.Windows.Forms.Label();
            this.lblURL = new System.Windows.Forms.Label();
            this.txtCat = new System.Windows.Forms.TextBox();
            this.lstPodcasts = new System.Windows.Forms.ListBox();
            this.lstEpisodes = new System.Windows.Forms.ListBox();
            this.lstCat = new System.Windows.Forms.ListBox();
            this.lblCats = new System.Windows.Forms.Label();
            this.lblPodEpi = new System.Windows.Forms.Label();
            this.lblPodEpiInfo = new System.Windows.Forms.Label();
            this.lblEpiInfo = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnNewPod
            // 
            this.btnNewPod.Location = new System.Drawing.Point(87, 220);
            this.btnNewPod.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNewPod.Name = "btnNewPod";
            this.btnNewPod.Size = new System.Drawing.Size(101, 23);
            this.btnNewPod.TabIndex = 0;
            this.btnNewPod.Text = "New...";
            this.btnNewPod.UseVisualStyleBackColor = true;
            // 
            // btnSavePod
            // 
            this.btnSavePod.Location = new System.Drawing.Point(191, 220);
            this.btnSavePod.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSavePod.Name = "btnSavePod";
            this.btnSavePod.Size = new System.Drawing.Size(101, 23);
            this.btnSavePod.TabIndex = 1;
            this.btnSavePod.Text = "Save";
            this.btnSavePod.UseVisualStyleBackColor = true;
            // 
            // btnDeletePod
            // 
            this.btnDeletePod.Location = new System.Drawing.Point(296, 220);
            this.btnDeletePod.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeletePod.Name = "btnDeletePod";
            this.btnDeletePod.Size = new System.Drawing.Size(101, 23);
            this.btnDeletePod.TabIndex = 2;
            this.btnDeletePod.Text = "Delete...";
            this.btnDeletePod.UseVisualStyleBackColor = true;
            // 
            // btnSaveCat
            // 
            this.btnSaveCat.Location = new System.Drawing.Point(592, 203);
            this.btnSaveCat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSaveCat.Name = "btnSaveCat";
            this.btnSaveCat.Size = new System.Drawing.Size(101, 23);
            this.btnSaveCat.TabIndex = 3;
            this.btnSaveCat.Text = "Save";
            this.btnSaveCat.UseVisualStyleBackColor = true;
            // 
            // btnNewCat
            // 
            this.btnNewCat.Location = new System.Drawing.Point(463, 203);
            this.btnNewCat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNewCat.Name = "btnNewCat";
            this.btnNewCat.Size = new System.Drawing.Size(101, 23);
            this.btnNewCat.TabIndex = 4;
            this.btnNewCat.Text = "New...";
            this.btnNewCat.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCat
            // 
            this.btnDeleteCat.Location = new System.Drawing.Point(719, 203);
            this.btnDeleteCat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeleteCat.Name = "btnDeleteCat";
            this.btnDeleteCat.Size = new System.Drawing.Size(101, 23);
            this.btnDeleteCat.TabIndex = 5;
            this.btnDeleteCat.Text = "Delete...";
            this.btnDeleteCat.UseVisualStyleBackColor = true;
            // 
            // cmbUpdateFreq
            // 
            this.cmbUpdateFreq.FormattingEnabled = true;
            this.cmbUpdateFreq.Location = new System.Drawing.Point(159, 186);
            this.cmbUpdateFreq.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbUpdateFreq.Name = "cmbUpdateFreq";
            this.cmbUpdateFreq.Size = new System.Drawing.Size(107, 21);
            this.cmbUpdateFreq.TabIndex = 7;
            // 
            // cmbCat
            // 
            this.cmbCat.FormattingEnabled = true;
            this.cmbCat.Location = new System.Drawing.Point(291, 186);
            this.cmbCat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbCat.Name = "cmbCat";
            this.cmbCat.Size = new System.Drawing.Size(107, 21);
            this.cmbCat.TabIndex = 8;
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
            // txtCat
            // 
            this.txtCat.Location = new System.Drawing.Point(463, 174);
            this.txtCat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCat.Name = "txtCat";
            this.txtCat.Size = new System.Drawing.Size(357, 20);
            this.txtCat.TabIndex = 13;
            // 
            // lstPodcasts
            // 
            this.lstPodcasts.FormattingEnabled = true;
            this.lstPodcasts.Location = new System.Drawing.Point(11, 11);
            this.lstPodcasts.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstPodcasts.Name = "lstPodcasts";
            this.lstPodcasts.Size = new System.Drawing.Size(387, 147);
            this.lstPodcasts.TabIndex = 14;
            // 
            // lstEpisodes
            // 
            this.lstEpisodes.FormattingEnabled = true;
            this.lstEpisodes.Location = new System.Drawing.Point(11, 290);
            this.lstEpisodes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstEpisodes.Name = "lstEpisodes";
            this.lstEpisodes.Size = new System.Drawing.Size(387, 147);
            this.lstEpisodes.TabIndex = 15;
            // 
            // lstCat
            // 
            this.lstCat.FormattingEnabled = true;
            this.lstCat.Location = new System.Drawing.Point(463, 24);
            this.lstCat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstCat.Name = "lstCat";
            this.lstCat.Size = new System.Drawing.Size(357, 134);
            this.lstCat.TabIndex = 16;
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
            // lblPodEpi
            // 
            this.lblPodEpi.AutoSize = true;
            this.lblPodEpi.Location = new System.Drawing.Point(8, 275);
            this.lblPodEpi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPodEpi.Name = "lblPodEpi";
            this.lblPodEpi.Size = new System.Drawing.Size(113, 13);
            this.lblPodEpi.TabIndex = 18;
            this.lblPodEpi.Text = "Podcast #x: Episode y";
            // 
            // lblPodEpiInfo
            // 
            this.lblPodEpiInfo.AutoSize = true;
            this.lblPodEpiInfo.Location = new System.Drawing.Point(461, 275);
            this.lblPodEpiInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPodEpiInfo.Name = "lblPodEpiInfo";
            this.lblPodEpiInfo.Size = new System.Drawing.Size(113, 13);
            this.lblPodEpiInfo.TabIndex = 19;
            this.lblPodEpiInfo.Text = "Podcast #x: Episode y";
            // 
            // lblEpiInfo
            // 
            this.lblEpiInfo.AutoSize = true;
            this.lblEpiInfo.Location = new System.Drawing.Point(461, 304);
            this.lblEpiInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEpiInfo.Name = "lblEpiInfo";
            this.lblEpiInfo.Size = new System.Drawing.Size(174, 13);
            this.lblEpiInfo.TabIndex = 20;
            this.lblEpiInfo.Text = "Information about choosen podcast";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(8, 187);
            this.txtURL.Margin = new System.Windows.Forms.Padding(2);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(147, 20);
            this.txtURL.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 443);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.lblEpiInfo);
            this.Controls.Add(this.lblPodEpiInfo);
            this.Controls.Add(this.lblPodEpi);
            this.Controls.Add(this.lblCats);
            this.Controls.Add(this.lstCat);
            this.Controls.Add(this.lstEpisodes);
            this.Controls.Add(this.lstPodcasts);
            this.Controls.Add(this.txtCat);
            this.Controls.Add(this.lblURL);
            this.Controls.Add(this.lblUpdateFreq);
            this.Controls.Add(this.lblCat);
            this.Controls.Add(this.cmbCat);
            this.Controls.Add(this.cmbUpdateFreq);
            this.Controls.Add(this.btnDeleteCat);
            this.Controls.Add(this.btnNewCat);
            this.Controls.Add(this.btnSaveCat);
            this.Controls.Add(this.btnDeletePod);
            this.Controls.Add(this.btnSavePod);
            this.Controls.Add(this.btnNewPod);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewPod;
        private System.Windows.Forms.Button btnSavePod;
        private System.Windows.Forms.Button btnDeletePod;
        private System.Windows.Forms.Button btnSaveCat;
        private System.Windows.Forms.Button btnNewCat;
        private System.Windows.Forms.Button btnDeleteCat;
        private System.Windows.Forms.ComboBox cmbUpdateFreq;
        private System.Windows.Forms.ComboBox cmbCat;
        private System.Windows.Forms.Label lblCat;
        private System.Windows.Forms.Label lblUpdateFreq;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.TextBox txtCat;
        private System.Windows.Forms.ListBox lstPodcasts;
        private System.Windows.Forms.ListBox lstEpisodes;
        private System.Windows.Forms.ListBox lstCat;
        private System.Windows.Forms.Label lblCats;
        private System.Windows.Forms.Label lblPodEpi;
        private System.Windows.Forms.Label lblPodEpiInfo;
        private System.Windows.Forms.Label lblEpiInfo;
        private System.Windows.Forms.TextBox txtURL;
    }
}

