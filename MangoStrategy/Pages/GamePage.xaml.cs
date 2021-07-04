using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MangoStrategy
{
    /// <summary>
    /// Interakční logika pro GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        Rectangle[] RectangleList = new Rectangle[800];
        MainWindow _this;
        Point _Point;
        int TimeMode = -1;
        int Hour = 0, Day = 1, Month = 1, Year = 2000;

        public GamePage(MainWindow Recived_this)
        {
            InitializeComponent();
            _this = Recived_this;
            GameTime();
            MakeMap();
        }

        public async void GameTime()
        {
            while (TimeMode != -2)
            {
                if (TimeMode == -1)
                {
                    await Task.Delay(100);
                }
                else if (TimeMode == 0)
                {
                    Hour++;
                    await Task.Delay(500);
                }
                else
                {
                    Hour++;
                    await Task.Delay(250);
                }

                if (Hour == 24)
                {
                    Hour = 0;
                    Day++;
                }
                if (Day == 31)
                {
                    Day = 1;
                    Month++;
                }
                if (Month == 13)
                {
                    Month = 1;
                    Year++;
                }

                TimeTextBlock.Text = Hour + ":00 " + Day + "." + Month + "." + Year;
            }
        }

        private void Notifications_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button ClickedButton = (Button)sender;
            if ((string)ClickedButton.Tag == "Plus")
            {
                if (MapSlider.Value + 10 <= MapSlider.Maximum)
                {
                    MapSlider.Value += 10;
                }
            }
            else if ((string)ClickedButton.Tag == "Minus")
            {
                if (MapSlider.Value - 10 >= MapSlider.Minimum)
                {
                    MapSlider.Value -= 10;
                }
            }

            //Time
            else if ((string)ClickedButton.Tag == "PauseTime")
            {
                ExtraTimeBtn.FontSize = 12;
                NormalTimeBtn.FontSize = 12;
                PauseTimeBtn.FontSize = 18;
                TimeMode = -1;
            }
            else if ((string)ClickedButton.Tag == "NormalTime")
            {
                ExtraTimeBtn.FontSize = 12;
                NormalTimeBtn.FontSize = 18;
                PauseTimeBtn.FontSize = 12;
                TimeMode = 0;
            }
            else if ((string)ClickedButton.Tag == "ExtraTime")
            {
                ExtraTimeBtn.FontSize = 18;
                NormalTimeBtn.FontSize = 12;
                PauseTimeBtn.FontSize = 12;
                TimeMode = 1;
            }

            //Menu buttons
            else if ((string)ClickedButton.Tag == "HideMenu")
            {
                if(FrameMenu.Visibility == Visibility.Visible)
                {
                    FrameMenu.Visibility = Visibility.Collapsed;
                }
                else
                {

                    FrameMenu.Visibility = Visibility.Visible;
                }
            }
            else if ((string)ClickedButton.Tag == "ResearchesMenu")
            {
                
            }
            else if ((string)ClickedButton.Tag == "DiplomaticMenu")
            {
                
            }
            else if ((string)ClickedButton.Tag == "LawsMenu")
            {

            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider _Slider = (Slider)sender;

            MapViewbox.Height = 9 * _Slider.Value;
            MapViewbox.Width = 16 * _Slider.Value;
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle _Rectangle = (Rectangle)sender;
            RectTagTextBox.Text = Convert.ToString(_Rectangle.Tag);
        }

        private void MapViewbox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _Point = e.GetPosition(MapViewbox);
            XYMPTextBox.Text = Convert.ToInt32(_Point.X) + " " + Convert.ToInt32(_Point.Y);
        }


        void MakeMap()
        {
            int i = 0;
            while (i != 800)
            {
                Rectangle NewRectangle = new Rectangle();
                NewRectangle.Width = 50;
                NewRectangle.Height = 50;
                NewRectangle.Fill = Brushes.DeepSkyBlue;
                NewRectangle.Stroke = Brushes.SkyBlue;
                NewRectangle.Tag = i;
                NewRectangle.MouseDown += Rectangle_MouseDown;
                MapWrapPanel.Children.Add(NewRectangle);
                RectangleList[i] = NewRectangle;
                i += 1;
            }
        }
    }
}
