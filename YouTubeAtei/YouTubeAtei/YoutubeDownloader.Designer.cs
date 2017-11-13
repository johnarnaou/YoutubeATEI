namespace YouTubeAtei
{
    partial class YoutubeDownloader
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
            this.downBT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.urlTB = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressLB = new System.Windows.Forms.Label();
            this.qualityBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.convertBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // downBT
            // 
            this.downBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.downBT.Location = new System.Drawing.Point(423, 267);
            this.downBT.Name = "downBT";
            this.downBT.Size = new System.Drawing.Size(75, 23);
            this.downBT.TabIndex = 0;
            this.downBT.Text = "Start";
            this.downBT.UseVisualStyleBackColor = true;
            this.downBT.Click += new System.EventHandler(this.downBT_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL:";
            // 
            // urlTB
            // 
            this.urlTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.urlTB.Location = new System.Drawing.Point(47, 6);
            this.urlTB.Name = "urlTB";
            this.urlTB.Size = new System.Drawing.Size(451, 20);
            this.urlTB.TabIndex = 2;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 238);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(486, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // progressLB
            // 
            this.progressLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressLB.Location = new System.Drawing.Point(12, 203);
            this.progressLB.Name = "progressLB";
            this.progressLB.Size = new System.Drawing.Size(486, 32);
            this.progressLB.TabIndex = 4;
            this.progressLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // qualityBox
            // 
            this.qualityBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.qualityBox.FormattingEnabled = true;
            this.qualityBox.Items.AddRange(new object[] {
            "360p",
            "480p",
            "720p",
            "1080p"});
            this.qualityBox.Location = new System.Drawing.Point(377, 52);
            this.qualityBox.Name = "qualityBox";
            this.qualityBox.Size = new System.Drawing.Size(121, 21);
            this.qualityBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select Video Quality:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Type:";
            // 
            // typeBox
            // 
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Items.AddRange(new object[] {
            "Mp4",
            "Flash",
            "Mobile"});
            this.typeBox.Location = new System.Drawing.Point(47, 52);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(121, 21);
            this.typeBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(148, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Convert To:";
            // 
            // convertBox
            // 
            this.convertBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.convertBox.FormattingEnabled = true;
            this.convertBox.Items.AddRange(new object[] {
            "Video",
            "Mp3"});
            this.convertBox.Location = new System.Drawing.Point(217, 119);
            this.convertBox.Name = "convertBox";
            this.convertBox.Size = new System.Drawing.Size(148, 21);
            this.convertBox.TabIndex = 10;
            // 
            // YoutubeDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 302);
            this.Controls.Add(this.convertBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.qualityBox);
            this.Controls.Add(this.progressLB);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.urlTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.downBT);
            this.Name = "YoutubeDownloader";
            this.Text = "Youtube Downloader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button downBT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox urlTB;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label progressLB;
        private System.Windows.Forms.ComboBox qualityBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox typeBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox convertBox;
    }
}

