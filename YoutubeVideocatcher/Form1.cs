using PokemonNewsUpdataer_V1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace YoutubeVideocatcher
{
    public partial class YoutubeCatcher : Form
    {
        public YoutubeCatcher()
        {
            
            InitializeComponent();
        }

        private void YoutubeCatcher_Load(object sender, EventArgs e)
        {
            
        }

        public void Download(object ff)
        {
            YouTubeClawer Clawer = (YouTubeClawer)(ff);
            try
            {
                Clawer.start();
            }
            catch
            {
                MessageBox.Show("失败...尝试检查vpn或链接");
            }
        }
        private void oneVideo_Click(object sender, EventArgs e)
        {
            string URL = VideoId.Text;
            if (URL.IndexOf("https", StringComparison.OrdinalIgnoreCase) >= 0)
            {

            }
            else if (URL.IndexOf("www.", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                URL = "https://" + URL;
            }
            else
            {
                URL = "https://www.youtube.com/watch?v=" + URL;
            }
            YouTubeClawer Clawer = new YouTubeClawer(URL, 1, 665, (DateTime.Now.ToLongDateString().ToString() +
                DateTime.Now.ToLongTimeString().ToString()));
            try
            {
                if (is480.Checked)
                {
                    Clawer.daudio = true;
                    //new Thread(Clawer.DownOneVideo).Start(URL);
                    //int stat = Clawer.DownOneVideo(URL);
                }
                if (is720.Checked)
                {
                    Clawer.Clarity = 720;
                    new Thread(Clawer.DownOneVideo).Start(URL);
                    //Clawer.DownOneVideo(URL);
                    //int stat = Clawer.DownOneVideo(URL);
                }
                if (is1080.Checked)
                {
                    Clawer.Clarity = 1080;
                    new Thread(Clawer.DownOneVideo).Start(URL);
                    //int stat = Clawer.DownOneVideo(URL);
                }
                if (clartext.Text != "")
                {
                    clartext.Text.Replace("p", "");
                    Clawer.Clarity = int.Parse(clartext.Text);
                    new Thread(Clawer.DownOneVideo).Start(URL);
                    //int stat = Clawer.DownOneVideo(URL);
                }

            }
            catch
            {
                MessageBox.Show("链接有误...");
            }
        }

        private void PageVideo_Click(object sender, EventArgs e)
        {
            YouTubeClawer Clawer = null;
            try
            {
                Clawer = new YouTubeClawer(PageURL.Text, int.Parse(Videos.Text), 665, (DateTime.Now.ToLongDateString().ToString() +
                     DateTime.Now.ToLongTimeString().ToString()));
                if (is720.Checked)
                    {
                        Clawer.Clarity = 720;
                        new Thread(Download).Start(Clawer);
                    //Clawer.start();

                    }
                    if (is1080.Checked)
                    {
                        Clawer.Clarity = 1080;
                        new Thread(Download).Start(Clawer);
                    }
            }
            catch
            {
                MessageBox.Show("视频数有误");
            }

        }
    }
}
