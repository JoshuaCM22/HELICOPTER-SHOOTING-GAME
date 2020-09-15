using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace POPPING_BALLOONS_GAME // Created by: Joshua C. Magoliman
{
    /// <summary>
    /// Interaction logic for Window_Introduction.xaml
    /// </summary>
    public partial class Window_Introduction : Window
    {
        #region Fields    
        public static bool isAudioOn;
        private static readonly string file = "ForAudio.txt";
        private CustomAudio customAudio = new CustomAudio("introduction_and_in_game.wav");
        #endregion

        #region Constructor  
        public Window_Introduction()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            CheckTheContentOfTheFile();
            CheckIfAudioIsMutedOrNot();
        }
        #endregion

        #region Event Handler Methods
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            customAudio.StopPlaying();
            Window_Game nextWindow = new Window_Game();
            this.Visibility = Visibility.Collapsed;
            nextWindow.ShowDialog();
        }
        private void OnClosing(object sender, System.EventArgs e)
        {
            customAudio.StopPlaying();
            Application.Current.Shutdown();
        }
        private void btnHighScores_Click(object sender, RoutedEventArgs e)
        {
            customAudio.StopPlaying();
            Window_HighScores nextWindow = new Window_HighScores();
            this.Visibility = Visibility.Collapsed;
            nextWindow.ShowDialog();
        }
        private void btnAudio_Click(object sender, RoutedEventArgs e)
        {
            if (isAudioOn == true)
            {
                isAudioOn = false;
                btnAudio.Content = new Image
                {
                    Source = new BitmapImage(new Uri("pack://application:,,,/Images/muted.png"))
                };
                customAudio.StopPlaying();
            }
            else if (isAudioOn == false)
            {
                isAudioOn = true;
                btnAudio.Content = new Image
                {
                    Source = new BitmapImage(new Uri("pack://application:,,,/Images/unmuted.png"))
                };
                customAudio.Play(true);
            }
            SavingTheContent();
        }
        #endregion

        #region User Defined Methods
        private void CheckTheContentOfTheFile()
        {
            if (File.Exists(file))
            {
                StreamReader read = new StreamReader(file);
                using (read)
                {
                    string content = read.ReadLine();
                    if (content != null)
                    {
                        isAudioOn = Convert.ToBoolean(content);
                    }
                }
            }
        }
        private void CheckIfAudioIsMutedOrNot()
        {
            if (isAudioOn == true)
            {
                btnAudio.Content = new Image
                {
                    Source = new BitmapImage(new Uri("pack://application:,,,/Images/unmuted.png"))
                };
                customAudio.Play(true);
            }
            else if (isAudioOn == false)
            {
                btnAudio.Content = new Image
                {
                    Source = new BitmapImage(new Uri("pack://application:,,,/Images/muted.png"))
                };
                customAudio.StopPlaying();
            }
        }
        private void SavingTheContent()
        {
            StreamWriter write = new StreamWriter(file, false);
            using (write)
            {
                write.WriteLine(Convert.ToString(isAudioOn));
            }
        }
        #endregion
    }
}