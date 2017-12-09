using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System;
using System.Security.Permissions;
using System.Runtime.InteropServices;

namespace Youtube_music_WPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<VideoResult> vRes;
        List<ChannelResult> cRes;
        JavascriptInterface JsInterop;
        public bool loopMusicMode;
        public MainWindow()
        {
            InitializeComponent();
            vRes = new List<VideoResult>();
            cRes = new List<ChannelResult>();
            JsInterop = new JavascriptInterface(this);
            wbMain.ObjectForScripting = JsInterop;
            this.Title = "Youtube Music";
            this.checkBox_Loop.IsEnabled = false;
            loopMusicMode = false;


            if ( System.IO.File.Exists("youtube-dl.exe") == false )
            {
                using (var client = new WebClient())
                {
                    Window1 waitwindow = new Window1();
                    waitwindow.Show();
                    client.DownloadFile( new Uri("https://youtube-dl.org/downloads/latest/youtube-dl.exe"), "youtube-dl.exe");
                    waitwindow.Close();
                }
            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            themeSwitch.IsChecked = Properties.Settings.Default.darktheme;           
        }


        /// <summary>
        /// Evenement lorsque l'utilisateur clique sur "Search"
        /// </summary>

        /* 
        Grace a l'api youtube, elle nous permet de recevoir des resultats de recherche
        (comme si vous tapez dans la barre de recherche youtube)
        ces données sont fournies au format JSON, l'utillisation de la dll de newtonsoft 
        est donc neccesaire afin de retrouver facilement ce qu'on recherche.
        une fois les infos récupérées, on les range dans des objets VideoResult ou ChannelResult
        et on stocke ceux-ci dans des collections. vRes pour les videos, cRes pour les chaines.
        (ne pas oublier qu'a chaque recherche il faut vider les collections)
        enfin en appelle une fonction qui nous servira pour l'affichage. 
        */
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            vRes.Clear();
            cRes.Clear();
            using (WebClient wc = new WebClient())
            {
                string query = "https://www.googleapis.com/youtube/v3/search?" +
                "part=snippet&type=video&videoCategoryId=10&maxResults=12&type=Music&key=AIzaSyADZPLzlfg0u0f4hJByfuLYgBeqKwfnQC0&q=" + searchBox.Text;
                wc.DownloadDataAsync(new Uri(query));
                wc.DownloadDataCompleted += DownloadVideosCompleted;
            }
            using (WebClient wc = new WebClient())
            {
                string query = "https://www.googleapis.com/youtube/v3/search?part=snippet&type=channel&maxResults=5&key=AIzaSyADZPLzlfg0u0f4hJByfuLYgBeqKwfnQC0&q=" + searchBox.Text;
                wc.DownloadDataAsync(new Uri(query));
                wc.DownloadDataCompleted += DownloadChannelsCompleted;
            }

        }

        private void DownloadVideosCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            dynamic res = JsonConvert.DeserializeObject(System.Text.Encoding.UTF8.GetString(e.Result));

            foreach (var item in res.items)
            {
                //need to cast item values into strings
                string a = item.id.videoId;
                string b = item.snippet.thumbnails.medium.url;
                string c = item.snippet.title;
                string d = item.snippet.channelTitle;
                string eee = item.snippet.channelId;

                VideoResult v = new VideoResult(a, b, c, d, eee);

                if (item.snippet.liveBroadcastContent == "none")
                {
                    v.broadcast = false;
                }
                if (item.snippet.liveBroadcastContent == "live")
                {
                    v.broadcast = true;
                }

                vRes.Add(v);
            }
            res = null;
            FillDataGrid(vRes);
        }

        private void DownloadChannelsCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            dynamic res = JsonConvert.DeserializeObject(System.Text.Encoding.UTF8.GetString(e.Result));
            foreach (var item in res.items)
            {
                //due to dynamic "item" variable, cant create object directly , must copy items values
                string a = item.snippet.title;
                string b = item.snippet.thumbnails.medium.url;
                string c = item.snippet.channelId;

                cRes.Add(new ChannelResult(a, b, c));

            }
            res = null;
            FillDataGrid(cRes);
        }

        /// <summary>
        /// Remplit la liste des chaines avec la collection de resultats fourni
        /// </summary>
        private void FillDataGrid(List<ChannelResult> chans )
        {
            cResData.Items.Clear();
            foreach(ChannelResult C in chans)
            {
                cResData.Items.Add(C);
            }

        }

        /// <summary>
        /// Remplit la liste de Videos avec la collection de resultats fourni
        /// </summary>
        private void FillDataGrid(List<VideoResult> vids)
        {
            vResData.Items.Clear();
            foreach (VideoResult V in vids)
            {
                if(V.broadcast == true )
                {
                    V.videoname = "*[LIVE]* " + V.videoname;
                }
                vResData.Items.Add(V);
            }
        }



        //just a convinient thing :)
        private void SearchBox_FirstFocus(object sender, RoutedEventArgs e)
        {
            if (searchBox.Text == "SEARCH MUSIC HERE    :)")
            {
                searchBox.Text = "";
                if (themeSwitch.IsChecked == true )
                {
                    searchBox.Foreground = Brushes.White;
                }
                else
                {
                    searchBox.Foreground = Brushes.Black;
                }
            }
        }
        //antoher convinient thing
        private void SearchBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == System.Windows.Input.Key.Enter)
            {
                Send.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }





        /// <summary>
        /// Evenement losque l'utilisateur clique sur une VIDEO 
        /// </summary>

        /*     Explications : 
        lancer l'executable externe pour obtenir le lien du fichier audio, 
        pour cela il faut lui donner en parametre l'id youtube de la video
        grace a l'objet VideoResult, les infos sont tres facilement recuperable
        une fois lancé, on a plus qu'a recuperer l'info de la Cmd appelé "output"
        ce lien il faut l'imbriquer dans une micro page HTML qu'on va rendre 
        sur le controle wbMain (webBrowser control)
        */
        private void VResData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (sender as ListBox).SelectedItem as VideoResult ;
            
            if (item != null)
            {
                string cmdargs;
                if (item.broadcast == true)
                {
                     cmdargs = "/c youtube-dl.exe -g -f 93 -s " + item.videoid;
                }
                else
                {
                     cmdargs = "/c youtube-dl.exe -g -f 140 -s " + item.videoid;
                }

                RunCmd(cmdargs,item);
            }
        }
        private async Task RunCmd(string args,VideoResult item )
        {
            
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            string output = await proc.StandardOutput.ReadToEndAsync();
            proc.Close();
            if (output != "")
            {
                output = output.Remove(output.Length - 1);
                if (item.broadcast == true)
                {
                    output = "<!DOCTYPE html><html><head><title></title><meta http-equiv='X-UA-Compatible' content='IE=edge,chrome=1'><meta charset='utf-8'></head><body><video controls autoplay id='videotag' style='width:100%;'><source src='" + output + "' >Your browser does not support the video tag.</video></body><script type='text/javaScript'>var vid = document.getElementById('videotag');vid.volume=" + Properties.Settings.Default.volume + ";</script></html>";

                    using (System.IO.StreamWriter sw = System.IO.File.CreateText("temp.html"))
                    {
                        sw.WriteLine(output);
                    }
                    Process.Start("temp.html", "--window-position=10,10 --window-size = 600, 600");
                    wbMain.NavigateToString("due to compatibility problems, the Livestream was opened on your default browser");
                    this.checkBox_Loop.IsEnabled = false;
                }
                else
                {
                    output = "<!DOCTYPE html><html><head><title></title><meta http-equiv='X-UA-Compatible' content='IE=edge,chrome=1'><meta charset='utf-8'></head><body style='background:black;'>" +
                             "<audio controls autoplay style='width:100%;height:45px;'id='audiotag'><source src='" + output + "' type='audio/mpeg'>Your browser does not support the audio tag.</audio></body>" +
                             "<script type='text/javaScript'>var vid = document.getElementById('audiotag');vid.volume="+Properties.Settings.Default.volume+ "; vid.loop="+ loopMusicMode.ToString().ToLower()+"; vid.onvolumechange = function(){window.external.GetVolumeChanged(vid.volume);};function EnableLoop(){vid.loop = true;} function DisableLoop(){vid.loop = false;} </script></html>";
                    wbMain.NavigateToString(output);

                    if (this.checkBox_Loop.IsEnabled == false)
                    {
                        this.checkBox_Loop.IsEnabled = true;
                    }
                }
                this.Title = " ► " + item.videoname;
                
            }
            else
            {
                wbMain.NavigateToString("<h1 style='font-family: modern, serif; font-size:14pt;' >This video is unavialble...    Sorry :/</h1>");
            }


            
        }

        
        /// <summary>
        /// Evenement quand l'utilisateur clique sur une chaine (liste a droite)
        /// </summary>
        /*
         *  un peu pres pareil que pour rechercher des videos
         *  sauf qu'on va choisir, a partir de l'api, seulement les videos de la chaine selectionné
         **/
        private void cResData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (sender as ListBox).SelectedItem as ChannelResult;
            if (item != null)
            {
                vRes.Clear();
                using (WebClient wc = new WebClient())
                {
                    string query = "https://www.googleapis.com/youtube/v3/search?" +
                    "part=snippet&order=date&maxResults=15&type=video&videoCategoryId=10&key=AIzaSyADZPLzlfg0u0f4hJByfuLYgBeqKwfnQC0&channelId=" + item.channelid;
                    wc.DownloadDataAsync(new Uri(query));
                    wc.DownloadDataCompleted += DownloadVideosCompleted;
                }
            }
        }

        //*********************************
        //      OPTIONS MENU FUNCTIONS
        //*********************************

        private void CheckUpdates_Button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("cmd.exe", "/c youtube-dl.exe -U");
        }

        private void themeSwitch_Unchecked(object sender, RoutedEventArgs e)
        {

            this.Background = Brushes.White;
            Send.Background = Brushes.LightGray;
            Send.Foreground = Brushes.Black;

            searchBox.Background = Brushes.White;
            searchBox.Foreground = Brushes.Black;
            if (searchBox.Text == "SEARCH MUSIC HERE    :)")
            {
                searchBox.Foreground = Brushes.Gray;
            }

            vResData.Background = Brushes.White;
            vResData.Foreground = Brushes.Black;
            vResData.BorderBrush = Brushes.Black;

            cResData.Background = Brushes.White;
            cResData.Foreground = Brushes.Black;
            cResData.BorderBrush = Brushes.Black;

            labelOption.Foreground = Brushes.Black;
            themeSwitch.Foreground = Brushes.Black;
            CheckUpdates_Button.Background = Brushes.LightGray;
            CheckUpdates_Button.Foreground = Brushes.Black;
            checkBox_Loop.Background = Brushes.LightGray;
            checkBox_Loop.Foreground = Brushes.Black;
            Properties.Settings.Default.darktheme = false;
            Properties.Settings.Default.Save();
        }

        private void themeSwitch_Checked(object sender, RoutedEventArgs e)
        {
            var color = new SolidColorBrush(Color.FromRgb((byte)20, (byte)20, (byte)20));

            this.Background = color;

            Send.Background = color;
            Send.Foreground = Brushes.White;

            searchBox.Background = color;
            searchBox.Foreground = Brushes.White;
            if (searchBox.Text == "SEARCH MUSIC HERE    :)")
            {
                searchBox.Foreground = Brushes.Gray;
            }


            vResData.Background = color;
            vResData.Foreground = Brushes.White;
            vResData.BorderBrush = Brushes.White;

            cResData.Background = color;
            cResData.Foreground = Brushes.White;
            cResData.BorderBrush = Brushes.White;

            labelOption.Foreground = Brushes.White;
            themeSwitch.Foreground = Brushes.White;
            CheckUpdates_Button.Background = color;
            CheckUpdates_Button.Foreground = Brushes.White;
            checkBox_Loop.Foreground = Brushes.White;


            Properties.Settings.Default.darktheme = true;
            Properties.Settings.Default.Save();

        }

        private void checkBox_Loop_Unchecked(object sender, RoutedEventArgs e)
        {
            JsInterop.SetAudioLoop(false);
        }

        private void checkBox_Loop_Checked(object sender, RoutedEventArgs e)
        {
            JsInterop.SetAudioLoop(true);
        }
    }
}
