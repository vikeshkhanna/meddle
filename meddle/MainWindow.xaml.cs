using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using iTunesLib;
using System.Net;
using HtmlAgilityPack;
using System.Diagnostics;

using System.ComponentModel;
using System.Runtime.InteropServices;

namespace iTunesHello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private delegate void UpdateDelegate(iTunesApp itunes);
        private UpdateDelegate updateDelegate;
      
        public MainWindow()
        {
            InitializeComponent();
            this.updateDelegate = new UpdateDelegate(this.UpdateDashboard);

            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth - 100;
            this.Height = System.Windows.SystemParameters.PrimaryScreenWidth - 100;
   
            /* itunes com events not working - adding a blocking while loop */
            //this.itunes.OnPlayerPlayEvent += new _IiTunesEvents_OnPlayerPlayEventEventHandler(this.itunes_OnPlayerPlayEvent);
            //this.itunes.OnPlayerStopEvent += new _IiTunesEvents_OnPlayerStopEventEventHandler(this.itunes_OnPlayerStopEvent);
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, EventArgs args)
        {
            iTunesApp itunes = new iTunesApp();
            string currentTrack = String.Empty;

            while (true)
            {
                try
                {
                    if (itunes.CurrentTrack != null && itunes.CurrentTrack.Name != currentTrack)
                    {
                        currentTrack = itunes.CurrentTrack.Name;
                        object[] dispatcherArgs = new object[1];
                        dispatcherArgs[0] = itunes;
                        this.Dispatcher.BeginInvoke(this.updateDelegate, dispatcherArgs);
                    }
                }
                catch (Exception err)
                {
                    Debug.WriteLine(err);
                }
            }
        }
       
        private void itunes_OnPlayerStopEvent(object track)
        {
            MessageBox.Show("Y u no stop?");
        }

        private void itunes_OnPlayerPlayEvent(object track)
        {
            this.Dispatcher.BeginInvoke(this.updateDelegate);
        }

        private void UpdateDashboard(iTunesApp itunes)
        {
            try
            {
                string songTitle =  itunes.CurrentTrack.Name;
                string songArtist = itunes.CurrentTrack.Artist;
                string guid = Guid.NewGuid().ToString();

                Image artwork = null;

                IITFileOrCDTrack track = (IITFileOrCDTrack)itunes.CurrentTrack;
                string songLyrics = track.Lyrics;
                BitmapImage bitmapImage = new BitmapImage();

                bitmapImage.BeginInit();
                   
                //Show the first artwork if at all
                try
                {
                    IITArtworkCollection artworkCollection = (IITArtworkCollection)(itunes.CurrentTrack.Artwork);
                    IITArtwork art = artworkCollection[1];
                    string tempPath = System.IO.Path.GetTempPath();
                    string fileName = "itunes_artwork.jpg" + guid;

                    art.SaveArtworkToFile(tempPath + fileName);
                    bitmapImage.UriSource = new Uri(tempPath + fileName);
                }
                catch (Exception err)
                {
                    bitmapImage.UriSource = new Uri(@"pack://application:,,,/iTunesHello;component/images/default_artwork.png");
                    Debug.WriteLine(err);
                }

                bitmapImage.EndInit();
                this.artworkImage.Source = bitmapImage;

                if (songTitle.Length > 0)
                {
                    this.songTitleLabel.Content = songTitle;
                    this.songTitleMainLabel.Content = songTitle;
                }

                if (songArtist.Length > 0)
                {
                    this.songArtistLabel.Content = songArtist;
                }

                if (artwork != null)
                {
                    this.artworkImage = artwork;
                }

                if (songLyrics.Length > 0)
                {
                    this.songLyricsLabel.Content = songLyrics;
                }
            }
            catch (Exception err)
            {

            }
        }
    }
}
