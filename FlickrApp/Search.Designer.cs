namespace FlickrApp
{
    partial class Search
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
            this.bwDownloadImages = new System.ComponentModel.BackgroundWorker();
            this.txtSearchBox = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panelSearchResult = new System.Windows.Forms.FlowLayoutPanel();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.lblImageResult = new System.Windows.Forms.Label();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.gbSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // bwDownloadImages
            // 
            this.bwDownloadImages.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwDownloadImages_DoWork);
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.Location = new System.Drawing.Point(53, 33);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Size = new System.Drawing.Size(627, 22);
            this.txtSearchBox.TabIndex = 1;
            this.txtSearchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchBox_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(708, 28);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(166, 32);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panelSearchResult
            // 
            this.panelSearchResult.AutoScroll = true;
            this.panelSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSearchResult.Location = new System.Drawing.Point(0, 0);
            this.panelSearchResult.Margin = new System.Windows.Forms.Padding(3, 100, 3, 3);
            this.panelSearchResult.Name = "panelSearchResult";
            this.panelSearchResult.Padding = new System.Windows.Forms.Padding(0, 100, 0, 0);
            this.panelSearchResult.Size = new System.Drawing.Size(1390, 732);
            this.panelSearchResult.TabIndex = 4;
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.lblImageResult);
            this.gbSearch.Controls.Add(this.lblErrorMessage);
            this.gbSearch.Controls.Add(this.txtSearchBox);
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSearch.Location = new System.Drawing.Point(0, 0);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(1390, 97);
            this.gbSearch.TabIndex = 4;
            this.gbSearch.TabStop = false;
            // 
            // lblImageResult
            // 
            this.lblImageResult.AutoSize = true;
            this.lblImageResult.Location = new System.Drawing.Point(50, 74);
            this.lblImageResult.Name = "lblImageResult";
            this.lblImageResult.Size = new System.Drawing.Size(86, 17);
            this.lblImageResult.TabIndex = 4;
            this.lblImageResult.Text = "ImageResult";
            this.lblImageResult.Visible = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblErrorMessage.Location = new System.Drawing.Point(978, 33);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(101, 17);
            this.lblErrorMessage.TabIndex = 3;
            this.lblErrorMessage.Text = "Error Message";
            this.lblErrorMessage.Visible = false;
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 732);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.panelSearchResult);
            this.Name = "Search";
            this.Text = "Search";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Search_Close);
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bwDownloadImages;
        private System.Windows.Forms.TextBox txtSearchBox;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.FlowLayoutPanel panelSearchResult;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.Label lblImageResult;
    }
}

