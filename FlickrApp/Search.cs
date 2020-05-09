using System;
using System.ComponentModel;
using System.Windows.Forms;
using FlickrSearch.Controller;
using FlickrSearch.Model;
using FlickrSearch;
using System.Configuration;

namespace FlickrApp
{
    public partial class Search : Form
    {
        private FlickrSearchRequest _flickrSearchRequest = null;
        private FlickrSearchService _flickrSearchService = null;

        public Search()
        {
            try
            {
                InitializeComponent();

                lblImageResult.Visible = true;
                lblErrorMessage.Visible = true;
                lblImageResult.Text = string.Empty;
                lblErrorMessage.Text = string.Empty;

                _flickrSearchRequest = new FlickrSearchRequest();
                _flickrSearchService = new FlickrSearchService(_flickrSearchRequest);

                _flickrSearchRequest.ApiKey = ConfigurationManager.AppSettings["api_key"];

                bwDownloadImages.WorkerSupportsCancellation = true;
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Exception in Search");
                Logger.WriteLog(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = string.Empty;
            lblImageResult.Text = string.Empty;

            if (!string.IsNullOrEmpty(txtSearchBox.Text))
            {
                //Cancel image download if the background thread is still working
                if (bwDownloadImages.IsBusy)
                {
                    bwDownloadImages.CancelAsync();
                }

                //Start a new search
                BeginSearch();
            }
        }

        /*
         * Handle the case when user hit enter key after entering a keyword
         */
        private void txtSearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        /*
         * When user closes the window, inform the background thread to exit
         */
        private void Search_Close(object sender, EventArgs e)
        {
            if (bwDownloadImages.IsBusy)
            {
                bwDownloadImages.CancelAsync();
            }
        }

        private void bwDownloadImages_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker helperBW = sender as BackgroundWorker;
            FlickrSearchResponse arg = (FlickrSearchResponse)e.Argument;

            //Clear all pictures before adding new
            this.Invoke(new Action(() =>
            {
                panelSearchResult.Controls.Clear();
            }));

            e.Result = BackgroundProcessPhotoDownload(helperBW, arg);

            if (helperBW.CancellationPending)
            {
                e.Cancel = true;
            }
        }


        /*
         * Function to download the image and resize it to the given size
         */
        private int BackgroundProcessPhotoDownload(BackgroundWorker bw, FlickrSearchResponse flickrSearchResponse)
        {
            int result = 0;

            if (flickrSearchResponse != null && flickrSearchResponse.photos != null && flickrSearchResponse.photos.photo != null)
            {
                foreach (var photo in flickrSearchResponse.photos.photo)
                {
                    if (bw.CancellationPending)
                        break;

                    string baseFlickrUrl = string.Format(Constants.PHOTO_URL,
                                                            photo.farm,
                                                            photo.server,
                                                            photo.id,
                                                            photo.secret);

                    PictureBox eachPictureBox = new PictureBox();
                    eachPictureBox.Image = Util.DownloadImageFromUrl(baseFlickrUrl);
                    eachPictureBox.Image = Util.ResizeImage(eachPictureBox.Image, Constants.IMAGE_RESIZE_WIDTH, Constants.IMAGE_RESIZE_HEIGHT);
                    eachPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                    eachPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Left;

                    //Display image in the UI
                    this.Invoke(new Action(() => this.panelSearchResult.Controls.Add(eachPictureBox)));
                }
            }
            return result;
        }

        private async void BeginSearch()
        {
            _flickrSearchRequest.Tags = txtSearchBox.Text.Trim();

            FlickrSearchResponse response = await _flickrSearchService.GetServiceResponse();

            bwDownloadImages.RunWorkerAsync(response);

            if (response != null)
            {
                if (response.stat == Constants.SEARCH_OK)
                {
                    if (response.photos != null && response.photos.total == 0)
                    {
                        lblImageResult.Text = "No record found!";
                    }
                    else
                    {
                        lblImageResult.Text = "Images for " + _flickrSearchRequest.Tags;
                    }
                }
                else
                {
                    lblErrorMessage.Text = response.message;
                    lblImageResult.Text = string.Empty;
                }
            }
        }
    }
}
