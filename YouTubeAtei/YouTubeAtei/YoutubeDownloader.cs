using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExtractor;

namespace YouTubeAtei
{
    public partial class YoutubeDownloader : Form
    {
        private string _path;
        private VideoDownloader _videoDownloader;
        private VideoInfo _video;
        private IEnumerable<VideoInfo> _videoInfos;

        private VideoType _vType;
        private int _vQuality;

        private int _progress = 0;

        private string _url;
        private string _file;
        private bool _conevert = false;

        private bool _doingWork = false;

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
            if (!_doingWork)
            {
                enableDisableControls();
                _doingWork = true;
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    progressLB.Text = "Downloading...PLEASE DO NOT CLOSE THIS WINDOW";
                    _path = folderBrowserDialog1.SelectedPath;

                    if (getConvertValue() == "Mp3")
                    {
                        _conevert = true;
                    }
                    _vType = getVideoType();
                    _vQuality = getQuality();

                    downloadVideo();
                } else
                {
                    reset();
                }
            }
            else
            {
                if (BW.IsBusy)
                {
                    BW.CancelAsync();
                }
                if (ConvertBW.IsBusy)
                {
                    ConvertBW.CancelAsync();
                }
                reset();
            }
        }

        private void downloadVideo()
        {
            _url = urlTB.Text;

            downBT.Text = "Cancel";

            if (_url != "")
            {
                _doingWork = true;
                progressBar1.Visible = true;
                progressBar1.Value = 0;
                BW.RunWorkerAsync();
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
                case "Flash":
                    return VideoType.Flash;
                case "Mobile":
                    return VideoType.Mobile;
                default:
                    return VideoType.Mp4;
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
                case "480p":
                    return 480;
                case "720p":
                    return 720;
                case "1080p":
                    return 1080;
                default:
                    return 360;
            }
        }

        private int getProgress()
        {
            return _progress;
        }

        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            BW.ReportProgress(20);

            _videoInfos = DownloadUrlResolver.GetDownloadUrls(_url);

            BW.ReportProgress(40);

            _video = _videoInfos.First(info => info.VideoType == _vType && info.Resolution == _vQuality);

            BW.ReportProgress(60);

            if (_video.RequiresDecryption)
            {
                DownloadUrlResolver.DecryptDownloadUrl(_video);
            }

            BW.ReportProgress(80);

            _file = Path.Combine(_path, _video.Title + " - " + DateTime.Now.Ticks.ToString() + _video.VideoExtension);

            BW.ReportProgress(90);

            _videoDownloader = new VideoDownloader(_video, Path.Combine(_path, _video.Title + " - " + DateTime.Now.Ticks.ToString() + _video.VideoExtension));

            _videoDownloader.DownloadProgressChanged += (bsender, args) => BW.ReportProgress((int)Math.Round(args.ProgressPercentage));


            _videoDownloader.Execute();
        }

        private void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = progressBar1.Maximum;

            progressBar1.Value = 0;
            progressLB.Text = "Dowlonading..";

            if (_conevert)
            {
                progressLB.Text = "Converting..";
                ConvertBW.RunWorkerAsync();
            } else
            {
                reset();
                showMessage();
            }
        }

        private void ConvertBW_DoWork(object sender, DoWorkEventArgs e)
        {
            ConvertBW.ReportProgress(35);
            string prms = "-y -i " + '"' + _file + '"' + " -vn -acodec copy " + " " + '"' + _path + "\\" + _video.Title + ".m4a" + '"';
            ConvertBW.ReportProgress(75);
            toMp3Convert(prms);
            File.Delete(_file);
        }

        private void ConvertBW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void ConvertBW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            reset();
            showMessage();
        }

        private void reset()
        {
            _conevert = false;
            _doingWork = false;
            downBT.Text = "Start";
            progressLB.Text = "";
            progressBar1.Visible = false;
            progressBar1.Value = progressBar1.Maximum;
            enableDisableControls();
        }

        private void enableDisableControls()
        {
            qualityBox.Enabled = !qualityBox.Enabled;
            typeBox.Enabled = !typeBox.Enabled;
            convertBox.Enabled = !convertBox.Enabled;
            urlTB.Enabled = !urlTB.Enabled;
        }

        private void showMessage()
        {
            DialogResult result = MessageBox.Show("Show Files ?", "Completed", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Process.Start("explorer.exe", _path);
            }
        }
    }
}
