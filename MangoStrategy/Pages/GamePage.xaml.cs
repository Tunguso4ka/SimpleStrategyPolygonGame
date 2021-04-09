using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MangoStrategy
{
    /// <summary>
    /// Interakční logika pro GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        List<Ellipse> Ellipses = new List<Ellipse>();
        MainWindow _this;
        Point _Point;
        bool PointChanged;

        public GamePage(MainWindow Recived_this)
        {
            InitializeComponent();
            _this = Recived_this;
            AddCity(50, 100, Brushes.Red);
            AddCity(1000, 1000, Brushes.Red);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button ClickedButton = (Button)sender;
            if ((string)ClickedButton.Tag == "Plus")
            {
                if (MapImage.Height < 4000)
                {

                }
            }
            else if ((string)ClickedButton.Tag == "Minus")
            {
                if (MapImage.Height > 720)
                {

                }
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
        }

        private void MapViewbox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _Point = e.GetPosition(MapCanvas);
            XYMousePosTextBlock.Text = " _Point X:" + _Point.X + " Y:" + _Point.Y;
        }

        public async void AddCityByClick(Brush CountryBrush)
        {
            PointChanged = false;
            int i = 50;
            while(i != 0)
            {
                await Task.Delay(100);
                _this.ConsoleTextBox.Text = "Click on Map. Time: " + Convert.ToString(i) + " X:" + _Point.X + " Y:" + _Point.Y;
                i--;
            }

            AddCity((int)_Point.X, (int)_Point.Y, CountryBrush);
        }
    }
}
