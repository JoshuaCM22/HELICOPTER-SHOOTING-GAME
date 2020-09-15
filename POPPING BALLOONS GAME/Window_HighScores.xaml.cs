using System.Windows;

namespace POPPING_BALLOONS_GAME // Created by: Joshua C. Magoliman
{
    /// <summary>
    /// Interaction logic for Window_HighScores.xaml
    /// </summary>
    public partial class Window_HighScores : Window
    {
        #region Fields    
        private CustomAudio customAudio = new CustomAudio("introduction_and_in_game.wav");
        #endregion

        #region Constructor  
        public Window_HighScores()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            CheckIfAudioMutedOrNot();
            Top10Only.Show(this.lblRankHeaderAndContent, this.lblDateHeaderAndContent, this.lblScoreHeaderAndContent);
        }
        #endregion

        #region Event Handler Methods
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            customAudio.StopPlaying();
            Window_Introduction nextWindow = new Window_Introduction();
            this.Visibility = Visibility.Collapsed;
            nextWindow.ShowDialog();
        }
        private void OnClosing(object sender, System.EventArgs e)
        {
            customAudio.StopPlaying();
            Application.Current.Shutdown();
        }
        #endregion

        #region User Defined Methods
        private void CheckIfAudioMutedOrNot()
        {
            if (Window_Introduction.isAudioOn == true)
            {
                customAudio.Play(true);
            }
        }
        #endregion
    }
}