using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExtractor;

namespace YouTubeAtei
{
    public partial class YoutubeDownloader : Form
    {
        public YoutubeDownloader()
        {
            InitializeComponent();
            progressBar1.Visible = false;
            qualityBox.SelectedIndex = 0;
            typeBox.SelectedIndex = 0;
        }

        private void downBT_Click(object sender, EventArgs e)
        {
            downloadVideo();
        }

        private void downloadVideo()
        {
            String url = urlTB.Text;
            if (url != "")
            {
                progressLB.Text = "Preparing...";
                IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(url);

                if (getConvertValue() == "Video")
                {
                    VideoInfo video = videoInfos.First(info => info.VideoType == getVideoType() && info.Resolution == getQuality());

                    if (video.RequiresDecryption)
                    {
                        DownloadUrlResolver.DecryptDownloadUrl(video);
                    }

                    var videoDownloader = new VideoDownloader(video, Path.Combine("C:/Users/johnarnaou/Desktop", video.Title + video.VideoExtension));

                    progressBar1.Visible = true;
                    progressBar1.Value = 0;

                    progressLB.Text = "Dowlonading..";

                    videoDownloader.DownloadProgressChanged += (sender, args) => progressBar1.Value = (int)Math.Round(args.ProgressPercentage);


                    videoDownloader.Execute();
                } else if(getConvertValue() == "Mp3")
                {
                    VideoInfo video = videoInfos.Where(info => info.CanExtractAudio).OrderByDescending(info => info.AudioBitrate).FirstOrDefault();

                    if (video.RequiresDecryption)
                    {
                        DownloadUrlResolver.DecryptDownloadUrl(video);
                    }

                    var audioDownloader = new AudioDownloader(video, Path.Combine("C:/Users/johnarnaou/Desktop", video.Title + video.AudioExtension));

                    progressBar1.Value = 0;
                    progressLB.Text = "Downloading...";
                    audioDownloader.DownloadProgressChanged += (sender, args) => progressBar1.Value = (int)Math.Round(args.ProgressPercentage * 0.85);
                    progressLB.Text = "Converting...";
                    progressBar1.Value = 0;
                    audioDownloader.AudioExtractionProgressChanged += (sender, args) => progressBar1.Value = (int)Math.Round(args.ProgressPercentage * 0.15);
                    audioDownloader.Execute();
                }

                progressLB.Text = "Done!";
            }
            else
            {
                progressLB.Text = "PLEASE ENTER A URL!";
            }
        }

        private VideoType getVideoType()
        {
            string type = typeBox.SelectedItem.ToString();

            switch(type)
            {
                case "Mp4":
                    return VideoType.Mp4;
                    break;
                case "Flash":
                    return VideoType.Flash;
                    break;
                case "Mobile":
                    return VideoType.Mobile;
                    break;
                default:
                    return VideoType.Mp4;
                    break;
            }
        }

        private string getConvertValue() => convertBox.SelectedItem.ToString();

        private int getQuality()
        {
            String quality = qualityBox.SelectedItem.ToString();

            switch (quality)
            {
                case "360p":
                    return 360;
                    break;
                case "480p":
                    return 480;
                    break;
                case "720p":
                    return 720;
                    break;
                case "1080p":
                    return 1080;
                    break;
                default:
                    return 360;
                    break;

            }
        }
    }
}
