using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace POPPING_BALLOONS_GAME // Created by: Joshua C. Magoliman
{
    /// <summary>
    /// Interaction logic for Window_Game.xaml
    /// </summary>
    public partial class Window_Game : Window
    {
        #region Fields    
        private bool isGameActive;
        private int speed;
        private int intervals;
        private int balloonsColors;
        private int horizontalAxis;
        private int missedBalloons;
        private int score;
        private string dateToday;
        private CustomAudio inGameAudio = new CustomAudio("introduction_and_in_game.wav");
        private CustomAudio gameOverAudio = new CustomAudio("gameover.wav");
        private DispatcherTimer timerGame = new DispatcherTimer();
        private Random randomNumber = new Random();
        private List<Rectangle> itemRemover = new List<Rectangle>();
        #endregion

        #region Constructor  
        public Window_Game()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            timerGame.Tick += timerGame_Tick;
            timerGame.Interval = TimeSpan.FromMilliseconds(20);
            StartGame();
        }
        #endregion

        #region Event Handler Methods
        private void timerGame_Tick(object sender, EventArgs e)
        {
            dateToday = DateTime.Now.ToString("MM/dd/yyyy");
            lblScore.Content = "Your Score: " + Top10Only.AddingCommasInScore(Convert.ToString(score));
            lblMissed.Content = "Missed: " + missedBalloons;
            // Decrease the value of field called intervals by 10.
            intervals -= 10;
            // If the value of field called intervals is less than 1.
            if (intervals < 1)
            {
                // Paints the area of an image using the class called ImageBrush.
                ImageBrush balloonImage = new ImageBrush();
                // Increment the field called balloonsColors by 1.
                balloonsColors += 1;
                // If the value of field called balloonsColors is greater than 5.
                if (balloonsColors > 5)
                {
                    // Re assign the value of field called balloonsColors.
                    balloonsColors = 1;
                }
                switch (balloonsColors)
                {
                    case 1:
                        balloonImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/balloon1.png"));
                        break;
                    case 2:
                        balloonImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/balloon2.png"));
                        break;
                    case 3:
                        balloonImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/balloon3.png"));
                        break;
                    case 4:
                        balloonImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/balloon4.png"));
                        break;
                    case 5:
                        balloonImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/balloon5.png"));
                        break;
                }
                // Draw a rectangle using the class called Rectangle.
                Rectangle newBalloon = new Rectangle
                {
                    Tag = "balloon",
                    Height = 70,
                    Width = 50,
                    Fill = balloonImage
                };
                // Set the location in the Canvas.
                Canvas.SetLeft(newBalloon, randomNumber.Next(50, 400));
                Canvas.SetTop(newBalloon, 600);
                // Add the new balloons in the Canvas.
                MyCanvas.Children.Add(newBalloon);
                // Re assign the value of the field called intervals.
                intervals = randomNumber.Next(90, 150);
            }
            // Using the foreach loop to control every balloons.
            foreach (var x in MyCanvas.Children.OfType<Rectangle>())
            {
                // Check if there are Rectangle that have a tag name of "balloon".
                if ((string)x.Tag == "balloon")
                {
                    horizontalAxis = randomNumber.Next(-5, 5);
                    Canvas.SetTop(x, Canvas.GetTop(x) - speed);
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - (horizontalAxis * -1));
                }
                // If the balloon exceeds the height.
                if (Canvas.GetTop(x) < 20)
                {
                    // Add that balloon in the list of rectangle.
                    itemRemover.Add(x);
                    CheckIfAudioMutedOrNot("missed_balloon.wav");
                    missedBalloons += 1;
                }
            }
            // Using the foreach loop to control every balloons.
            foreach (Rectangle y in itemRemover)
            {
                // Remove that balloons in the Canvas.
                MyCanvas.Children.Remove(y);
            }
            // If the field called missedBalloons have the value of greater than 9.
            if (missedBalloons > 9)
            {
                // Invoke this user defined function called GameOver().
                GameOver();
            }
            // If the field called score have the value of greater than 10.
            if (score > 10)
            {
                speed = 5; // Re assign the value of field called speed.
            }
        }
        private void PopBalloons(object sender, MouseButtonEventArgs e)
        {
            if (isGameActive)
            {
                if (e.OriginalSource is Rectangle)
                {
                    Rectangle activeRectangle = (Rectangle)e.OriginalSource;
                    MyCanvas.Children.Remove(activeRectangle);
                    CheckIfAudioMutedOrNot("pop_balloon.wav");
                    score += 1;
                }
            }
        }
        private void OnClosing(object sender, EventArgs e)
        {
            inGameAudio.StopPlaying();
            gameOverAudio.StopPlaying();
            Application.Current.Shutdown();
        }
        #endregion

        #region User Defined Methods
        private void StartGame()
        {
            timerGame.Start();
            missedBalloons = 0;
            score = 0;
            intervals = 90;
            isGameActive = true;
            speed = 3;
            // Using the foreach loop to control every balloons.
            foreach (var x in MyCanvas.Children.OfType<Rectangle>())
            {
                itemRemover.Add(x); // Add the all the balloons that inside of Canvas.
            }
            // Remove each items in the list of rectangle called itemRemover inside of the Canvas.
            foreach (Rectangle y in itemRemover)
            {
                MyCanvas.Children.Remove(y);
            }
            // Clear all the items.
            itemRemover.Clear();
            // Set the date today.
            dateToday = DateTime.Now.ToString("MM/dd/yyyy");
            // Invoke this user defined function called PlayInGameAudio().
            PlayInGameAudio();
        }
        private void CheckIfAudioMutedOrNot(string param_NameOfWavFile)
        {
            if (Window_Introduction.isAudioOn == true)
            {
                CustomAudio customAudio = new CustomAudio(param_NameOfWavFile);
                customAudio.Play(false);
            }
        }
        private void PlayInGameAudio()
        {
            if (Window_Introduction.isAudioOn == true)
            {
                inGameAudio.Play(true);
            }
        }
        private void GameOver()
        {
            lblMissed.Content = "Missed: " + missedBalloons;
            isGameActive = false;
            timerGame.Stop();
            Top10Only.CheckResultInTop10Only(dateToday, Convert.ToInt32(score));
            inGameAudio.StopPlaying();
            if (Window_Introduction.isAudioOn == true)
            {
                gameOverAudio.Play(false);
            }
            MessageBoxResult result = MessageBox.Show("Your Score: " + score + Environment.NewLine + "Missed: " + missedBalloons + Environment.NewLine + Environment.NewLine + "Do you want to play again?", "GAME OVER", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (result == MessageBoxResult.Yes)
            {
                gameOverAudio.StopPlaying();
                StartGame();
            }
            else if (result == MessageBoxResult.No)
            {
                gameOverAudio.StopPlaying();
                Window_Introduction nextWindow = new Window_Introduction();
                this.Visibility = Visibility.Collapsed;
                nextWindow.ShowDialog();
            }
        }
        #endregion
    }
}