using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            convertBox.SelectedIndex = 1;
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

                VideoInfo video = videoInfos.First(info => info.VideoType == getVideoType() && info.Resolution == getQuality());


                if (video.RequiresDecryption){
                    DownloadUrlResolver.DecryptDownloadUrl(video);
                }

                progressLB.Text = "Dowlonading..";

                string file = Path.Combine("C:/Users/johnarnaou/Desktop", video.Title + video.VideoExtension);

                var videoDownloader = new VideoDownloader(video, Path.Combine("C:/Users/johnarnaou/Desktop", video.Title + video.VideoExtension));

                progressBar1.Visible = true;
                progressBar1.Value = 0;

                videoDownloader.DownloadProgressChanged += (sender, args) => progressBar1.Value = (int)Math.Round(args.ProgressPercentage);


                videoDownloader.Execute();

               if(getConvertValue() == "Mp3")
                {
                    string prms =  "-y -i " + '"' + file + '"' + " -vn -acodec copy " + " " + '"' + "C:\\Users\\johnarnaou\\Desktop" + "\\" + video.Title + ".m4a" + '"';
                    progressBar1.Visible = false;
                    progressLB.Text = "Converting... PLEASE WAIT!";
                    toMp3Convert(prms);
                    File.Delete(file);
                }
                
                progressLB.Text = "Done!";
            }
            else
            {
                progressLB.Text = "PLEASE ENTER A URL!";
            }
        }


        private void toMp3Convert(String parameters)
        {
            Process myProcess = new Process();
            string cmd = parameters;
            
            try
            {
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = Application.StartupPath + "\\ffmpeg.exe";
                Console.WriteLine(Application.StartupPath + "\\ffmpeg.exe");
                myProcess.StartInfo.Arguments = cmd;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.RedirectStandardError = true;
                myProcess.Start();

                while (!myProcess.StandardError.EndOfStream)
                {
                    string line = myProcess.StandardError.ReadLine();
                    if (line.Contains("frame="))
                    {
                        String currentFramestr = line.Substring(7, 5);
                        int currentFrameInt = Int32.Parse(currentFramestr);
                    }
                }

                myProcess.WaitForExit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
