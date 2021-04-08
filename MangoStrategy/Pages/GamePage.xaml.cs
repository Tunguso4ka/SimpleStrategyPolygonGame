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
        public GamePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button ClickedButton = (Button)sender;
            if ((string)ClickedButton.Tag == "Plus")
            {
                if (MapImage.Height < 5760)
                {
                    MapImage.Height *= 1.5;
                    MapImage.Width *= 1.5;
                }
            }
            else if ((string)ClickedButton.Tag == "Minus")
            {
                if (MapImage.Height > 720)
                {
                    MapImage.Height /= 1.5;
                    MapImage.Width /= 1.5;
                }
            }
        }
    }
}
