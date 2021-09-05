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
        List<Ellipse> Ellipses = new List<Ellipse>();
        List<System.Windows.Shapes.Path> Paths = new List<System.Windows.Shapes.Path>();
        MainWindow _this;
        Point _Point;
        int TimeMode = -1;
        int Hour = 0, Day = 1, Month = 1, Year = 2000;

        public GamePage(MainWindow Recived_this)
        {
            InitializeComponent();
            _this = Recived_this;
            LoadMap();
            GameTime();
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
        }

        public void AddCity(int X, int Y, Brush CountryBrush)
        {
            Ellipse _Ellipse = new Ellipse();
            _Ellipse.Fill = CountryBrush;
            _Ellipse.Width = 15;
            _Ellipse.Height = 15;
            Canvas.SetLeft(_Ellipse, X);
            Canvas.SetTop(_Ellipse, Y);

            MapCanvas.Children.Add(_Ellipse);

            Ellipses.Add(_Ellipse);

            _this.ConsoleTextBox.Text = "New City added in X: " + Convert.ToString(X) + " Y: " + Convert.ToString(Y);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider _Slider = (Slider)sender;

            MapViewbox.Height = 23 * _Slider.Value;
            MapViewbox.Width = 35 * _Slider.Value;

            MapCanvas.Children.Clear();
            
            for (int i = 0; i < Ellipses.Count; i++)
            {
                Ellipse _Ellipse = Ellipses[i];
                _Ellipse.Height = 0.2 * _Slider.Value;
                _Ellipse.Width = 0.2 * _Slider.Value;
                MapCanvas.Children.Add(_Ellipse);
            }
            for (int i = 0; i < Paths.Count; i++)
            {
                System.Windows.Shapes.Path _Path = Paths[i];
                MapCanvas.Children.Add(_Path);
            }
        }

        private void MapViewbox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _Point = e.GetPosition(MapCanvas);
            XYMPTextBox.Text = Convert.ToInt32(_Point.X) + " " + Convert.ToInt32(_Point.Y);
        }

        public async void AddCityByClick(Brush CountryBrush)
        {
            int i = 500;
            while(i != 0)
            {
                await Task.Delay(10);
                _this.ConsoleTextBox.Text = "Click on Map. Time: " + Convert.ToString(i) + " X:" + _Point.X + " Y:" + _Point.Y;
                i--;
            }

            AddCity((int)_Point.X, (int)_Point.Y, CountryBrush);
        }

        public async void AddPathByClick(Brush CountryBrush)
        {
            int i = 500;
            while (i != 0)
            {
                await Task.Delay(10);
                _this.ConsoleTextBox.Text = "Click on Map. Time: " + Convert.ToString(i) + " X:" + _Point.X + " Y:" + _Point.Y;
                i--;
            }

            //AddPath((int)_Point.X, (int)_Point.Y, CountryBrush);
        }

        public void AddPath(double X0, double Y0, double X1, double Y1, Brush CountryBrush)
        {
            System.Windows.Shapes.Path _Path = new System.Windows.Shapes.Path();
            _Path.Stroke = CountryBrush;
            _Path.StrokeThickness = 2;
            Geometry _Geometry = Geometry.Parse("M " + Convert.ToString(Convert.ToInt32(X0)) + "," + Convert.ToString(Convert.ToInt32(Y0)) + " " + Convert.ToString(Convert.ToInt32(X1)) + "," + Convert.ToString(Convert.ToInt32(Y1)));
            _Path.Data = _Geometry;

            MapCanvas.Children.Add(_Path);

            Paths.Add(_Path);

            _this.ConsoleTextBox.Text = "Map AddPath " + Convert.ToString(X1) + " " + Convert.ToString(Y1);
        }

        public void LoadProvince(int ProvinceNum)
        {
            StreamReader _StreamReader = new StreamReader(Environment.CurrentDirectory + @"\Material\Provinces\" + ProvinceNum + ".txt");
            string CoordsString;
            string[] Coords;
            double LastX = 0;
            double LastY = 0;
            double FirstX = 0;
            double FirstY = 0;
            while ((CoordsString = _StreamReader.ReadLine()) != null)
            {
                Coords = CoordsString.Split(' ');
                if(Coords.Length == 4)
                {
                    AddPath(Convert.ToDouble(Coords[0]), Convert.ToDouble(Coords[1]), Convert.ToDouble(Coords[2]), Convert.ToDouble(Coords[3]), Brushes.Red);
                    FirstX = Convert.ToDouble(Coords[0]);
                    FirstY = Convert.ToDouble(Coords[1]);
                    LastX = Convert.ToDouble(Coords[2]);
                    LastY = Convert.ToDouble(Coords[3]);
                }
                else
                {
                    AddPath(LastX, LastY, Convert.ToDouble(Coords[0]), Convert.ToDouble(Coords[1]), Brushes.Red);
                    LastX = Convert.ToDouble(Coords[0]);
                    LastY = Convert.ToDouble(Coords[1]);
                }
            }
            AddPath(LastX, LastY, FirstX, FirstY, Brushes.Red);
            _StreamReader.Dispose();
        }

        public void ClearMap()
        {
            MapCanvas.Children.Clear();
            Ellipses.Clear();
            Paths.Clear();
        }

        public void LoadMap()
        {
            StreamReader _StreamReader = new StreamReader(Environment.CurrentDirectory + @"\Material\Provinces\Provinces.txt");
            string Numstring;
            while ((Numstring = _StreamReader.ReadLine()) != null)
            {
                LoadProvince(Convert.ToInt32(Numstring));
            }
            _StreamReader.Dispose();
        }
    }
}
