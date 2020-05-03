using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace PokemonNewsUpdataer_V1
{
    class YouTubeClawer
    {
        public string URL;
        public int Videos;
        public int Clarity;
        public string Title;
        public bool daudio = false;
        //private int index = 1;
        private string BaseURL = @"https://www.youtube.com/watch?v=";
        private string cookie = "VISITOR_INFO1_LIVE=j3b2-2HgFTk; PREF=f1=50000000&al=zh-CN&f5=30; _ga=GA1.2.1867203254.1494992134; CONSENT=YES+CN.zh-CN+20160815-07-0; YSC=WqvbUE0zSsE";
        //private string path;

        public YouTubeClawer(string URL, int Videos, int Clarity, string Title = "Video")
        {
            this.URL = URL;
            this.Videos = Videos;
            this.Clarity = Clarity;
            this.Title = Title.Replace(':', ' ');
            //this.path = System.Environment.CurrentDirectory + "/pokemonnews";
        }

        private string GetHtml(string URL)
        {
            WebClient webclient = new WebClient();
            webclient.Headers.Add(HttpRequestHeader.Cookie, cookie);
            byte[] pageData = webclient.DownloadData(URL);
            string pageHtml = Encoding.UTF8.GetString(pageData);
            return pageHtml;
        }



        public string GetId()
        {
            string Html = GetHtml(URL);
            string[] Idlist = GetVideolist(Html);
            return Idlist[0];
        }

        public string Getname(string pageurl)
        {
            string Html = GetHtml(pageurl);
            string pattern = @"<title>(?<name>.*?)</title>";
            Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection namelist = reg.Matches(Html);
            return namelist[0].Result("${name}");
        }

        //public string GetId(string pageurl)
        //{
        //    string Html = GetHtml(pageurl);
        //    return GetVideolist(Html)[0];
        //}

        private string[] GetVideolist(string Html)
        {
            string pattern = @"data-context-item-id=""(?<Videoid>.[^""]*)""";
            //Console.WriteLine(pattern);
            Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection Videolist = reg.Matches(Html);
            string[] VideoIdlist = new string[Videolist.Count];
            int index = 0;
            foreach (Match VideoId in Videolist)
            {
                string Videoidt = VideoId.Result("${Videoid}");
                VideoIdlist[index++] = Videoidt;
                //Console.WriteLine(Videoidt);
            }
            return VideoIdlist;
        }

        private string GetVideo(string Html)
        {
            string pattern = null;
            if (Clarity == 720)
            {
                pattern = @"quality=hd720.*?url=(?<Video>.[^=]*?Fmp4.[^=]*?)(,|\\u0026)";
            }
            else if (Clarity == 1080)
            {
                pattern = @"quality_label=1080p.*?url=(?<Video>.[^=]*?Fmp4.[^=]*?)(,|\\u0026)";
            }
            else
            {
                pattern = @"quality_label=480p.*?url=(?<Video>.[^=]*?Fmp4.[^=]*?)(,|\\u0026)";
            }
            Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection mc = reg.Matches(Html);
            if (mc.Count == 0) return null;
            string Video = mc[0].Result("${Video}");
            if ((Video.Contains("itag%3D137") && Clarity == 1080) || (Video.Contains(@"itag%3D22") && Clarity == 720) || (Video.Contains(@"itag%3D135") && Clarity == 480))
            {
                return changeurl(Video);
            }
            else
            {
                return null;
            }
        }

        private string GetVideonew(string Html)
        {
            string pattern = null;
            if (Clarity == 720)
            {
                pattern = "url.{0,10}\"(?<Video>http.[^\"]*?)\".{0,10}mimeType.{0,20}mp4.{0,500}qualityLabe.{0,10}720p";
            }
            else if (Clarity == 1080)
            {
                pattern = "url.{0,10}\"(?<Video>http.[^\"]*?)\".{0,10}mimeType.{0,20}mp4.{0,500}qualityLabe.{0,10}1080p";
            }
            else
            {
                pattern = "url.{0,10}\"(?<Video>http.[^\"]*?)\".{0,10}mimeType.{0,20}mp4.{0,500}qualityLabe.{0,10}" + Clarity.ToString()+"p";
            }
            Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection mc = reg.Matches(Html);
            if (mc.Count == 0) return null;
            string Video = mc[0].Result("${Video}");
            return changeurlnew(Video);
        }
        //private string GetVideonew(string Html)
        //{
        //    string pattern = null;
        //    if (Clarity == 720)
        //    {
        //        pattern = "url\".{0,10}\"(?<Video>http.*?)\".{0,10}mimeType.{0,20}mp4.{0,500}qualityLabe.{0,10}720p";
        //    }
        //    else if (Clarity == 1080)
        //    {
        //        pattern = "url.{0,10}\"(?<Video>http.*?)\".{0,10}mimeType.{0,20}mp4.{0,500}qualityLabe.{0,10}1080p";
        //    }
        //    else
        //    {
        //        pattern = "url.{0,10}\"(?<Video>http.*?)\".{0,10}mimeType.{0,20}mp4.{0,500}qualityLabe.{0,10}480p";
        //    }
        //    Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
        //    MatchCollection mc = reg.Matches(Html);
        //    if (mc.Count == 0) return null;
        //    string Video = mc[0].Result("${Video}");
        //    return changeurlnew(Video);
        //}

        //private string GetVideonew(string Html)
        //{
        //    string pattern = null;
        //    if (Clarity == 720)
        //    {
        //        pattern = "mimeType.{0,20}mp4.{0,500}qualityLabe.{0,14}720p.*?url.{0,10}\"(?<Video>http.*?)\"";
        //    }
        //    else if (Clarity == 1080)
        //    {
        //        pattern = "mimeType.{0,20}mp4.{0,500}qualityLabe.{0,10}1080p.*?url.{0,10}\"(?<Video>http.*?)\"";
        //    }
        //    else
        //    {
        //        pattern = "mimeType.{0,20}mp4.{0,500}qualityLabe.{0,10}360p.*?url.{0,10}\"(?<Video>http.*?)\"";
        //    }
        //    Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
        //    MatchCollection mc = reg.Matches(Html);
        //    if (mc.Count == 0) return null;
        //    string Video = mc[0].Result("${Video}");
        //    return changeurlnew(Video);
        //}

        private string Getmusic(string Html)
        {
            string pattern = "url.{0,10}\"(?<musicurl>http.[^\"]*?)\".{0,10}mimeType.{0,20}audio";
            Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection mc = reg.Matches(Html);
            string musicurl = mc[0].Result("${musicurl}");
            return changeurlnew(musicurl);
        }

        //private string Getmusic(string Html)
        //{
        //    string pattern = @"type=audio.*?url=(?<musicurl>.[^=]*?)(,|\\u0026)";
        //    Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
        //    MatchCollection mc = reg.Matches(Html);
        //    string musicurl = mc[0].Result("${musicurl}");
        //    return changeurl(musicurl);
        //}

        private void DownOneFile(string url, string type = ".mp4", int index = 0)
        {
            WebClient webclient = new WebClient();
            webclient.Headers.Add(HttpRequestHeader.Cookie, cookie);
            string path = "Videos/" /*+ index.ToString()*/ + Title + ' ' + Clarity + 'p' + type;
            if (index != 0)
            {
                path = "Videos/" + index + ". "/*+ index.ToString()*/ + Title + ' ' + Clarity + 'p' + type;
            }
            webclient.DownloadFile(url, path);

            //f2.Show();
            //webclient.DownloadDataAsync(new Uri(url), path);
            //webclient.DownloadProgressChanged += Webclient_DownloadProgressChanged;

        }
        //YoutubeVideocatcher.Form2 f2 = new YoutubeVideocatcher.Form2();

        //private void Webclient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        //{
        //    Action<DownloadProgressChangedEventArgs> OnChange = ProceChange;
        //    OnChange.Invoke(e, f2);
        //}
        protected void ProceChange(DownloadProgressChangedEventArgs e, YoutubeVideocatcher.Form2 f2)
        {
            f2.progressBar1.Value = e.ProgressPercentage;
        }

        private void creapath(string gg = "pokemonnews")
        {
            DirectoryInfo dir = new DirectoryInfo(gg);
            if (!Directory.Exists(gg))
            {
                dir.Create();
            }
        }

        private string changeurl(string url)
        {
            return url.Replace("%2Fvideo", "/video").Replace("%3D", "=").Replace("%3A%2F%2F", "://").Replace("%25", "%").Replace("%26", "&").Replace("%3F", "?");

        }

        private string changeurlnew(string url)
        {
            return url.Replace("\\", "").Replace("u0026", "&");

        }

        public void startandemail(Mailer email)
        {
            start();
            if (Clarity == 1080)
            {
                string[] a = { "pokemonnews/" + Title + Clarity + 'p' + ".mp4", "pokemonnews/" + Title + Clarity + 'p' + ".mp3"};
                //new Thread(delegate () { email.Sender(Title, "视频资源", a); });
            }
            else if (Clarity == 720)
            {
                string[] a = { "pokemonnews/" + Title + Clarity + 'p' + ".mp4"};
                //new Thread(delegate () { email.Sender(Title, "视频资源", a); });
            }
            else
            {

            }
        }

        public void DownOneVideo(object URL1)
        {
            creapath("Videos");
            
            string URL = (string)URL1;
            string VideoDown = null;
            int looplimit = 0;
            string VideoHtml = null;
            if (Clarity != 480)
            {
                while (VideoDown == null && looplimit < 10)
            {
                VideoHtml = GetHtml(URL);
                VideoDown = GetVideo(VideoHtml);
                if (VideoDown == null)
                    {
                        VideoDown = GetVideonew(VideoHtml);
                    }
                looplimit++;
            }
            if (looplimit == 10)
            {
                Console.WriteLine("找不到或不存在此" + Clarity.ToString() + "p视频资源");
                Console.WriteLine(Title + " 任务执行完毕");
                return;
            }
            }
            else
            {
                VideoHtml = GetHtml(URL);
            }
            if (daudio &&(  Clarity == 1080 || Clarity == 480))
            {
                string music = Getmusic(VideoHtml);
                Console.WriteLine("音频源链接\n" + music);
                while (true)
                {
                    try
                    {
                        DownOneFile(music, ".mp3");
                        break;
                    }
                    catch
                    {
                        Console.WriteLine(Title + " music fail... retry");
                    }
                }
            }
            Console.WriteLine("视频源链接\n" + VideoDown);
            while (true)
            {
                try
                {
                    DownOneFile(VideoDown);
                    MessageBox.Show(Title + " 下载完成!");
                    break;
                }
                catch
                {
                    Console.WriteLine(Title + Clarity + "p video fail... retry");
                }
            }
            return;
        }

        public int start()
        {
            try
            {
                Console.WriteLine(Title + Clarity + "p 任务开始执行");
                creapath();
                string Html = GetHtml(URL);
                string[] videolist = GetVideolist(Html);
                for (int i = 0; i < Math.Min(Videos, videolist.Length); ++i)
                {
                    string VideoDown = null;
                    int looplimit = 0;
                    string VideoHtml = null;
                    while (VideoDown == null && looplimit < 10)
                    {
                        VideoHtml = GetHtml(BaseURL + videolist[i]);
                        VideoDown = GetVideo(VideoHtml);
                        looplimit++;
                    }

                    if (looplimit == 10)
                    {
                        Console.WriteLine("找不到或不存在此" + Clarity.ToString() + "p视频资源");
                        Console.WriteLine(Title + " 任务执行完毕");
                        return 404;
                    }

                    if (Clarity == 1080)
                    {
                        string music = Getmusic(VideoHtml);
                        Console.WriteLine("音频源链接\n" + music);
                        while (true)
                        {
                            try
                            {
                                DownOneFile(music, ".mp3", i);
                                break;
                            }
                            catch
                            {
                                Console.WriteLine(Title + " music fail... retry");
                            }
                        }
                    }
                    Console.WriteLine("视频源链接\n" + VideoDown);
                    while (true)
                    {
                        try
                        {
                            DownOneFile(VideoDown, ".mp4" ,i);
                            break;
                        }
                        catch
                        {
                            Console.WriteLine(Title + Clarity + "p video fail... retry");
                        }
                    }
                }
                Console.WriteLine(Title + Clarity + "p 任务执行完毕");
                return 200;
            }
            catch
            {
                Console.WriteLine(Title + Clarity + "p 任务失败!");
                return 502;
            }
        }
    }
}
