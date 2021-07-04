using System;
using System.Windows;
using System.Windows.Media;

namespace MangoStrategy
{
    class ConsoleClass
    {
        MainWindow RecMainWindow;
        string[] ConsoleRequest;
        public void Recieved( MainWindow RecievedMainWindow, string RecievedConsoleRequest)
        {
            RecMainWindow = RecievedMainWindow;
            ConsoleRequest = RecievedConsoleRequest.Split(' ');
            Request();
        }

        public void Sort(MainWindow RecievedMainWindow, string RecievedConsoleRequest)
        {
            RecMainWindow = RecievedMainWindow;
            ConsoleRequest = RecievedConsoleRequest.Split(' ');
            if (ConsoleRequest.Length == 1)
            {
                for (int i = 0; i > 10; i++)
                {
                    //if(ConsoleRequest[0])
                }
            }
        }

        void Request()
        {
            if(ConsoleRequest[0].Equals("App", StringComparison.OrdinalIgnoreCase))
            {
                AppScenario();
            }
            else if (ConsoleRequest[0].Equals("Help", StringComparison.OrdinalIgnoreCase))
            {
                HelpScenario();
            }
            else if (ConsoleRequest[0].Equals("Map", StringComparison.OrdinalIgnoreCase))
            {
                MapScenario();
            }
            else
            {
                RecMainWindow.ConsoleTextBox.Text = "Error: " + ConsoleRequest[0] + " dont exist.";
            }
        }

        void AppScenario()
        {
            try
            {
                if (ConsoleRequest[1].Equals("DarkMode", StringComparison.OrdinalIgnoreCase))
                {
                    if (ConsoleRequest[2].Equals("t", StringComparison.OrdinalIgnoreCase))
                    {
                        Properties.Settings.Default.DarkMode = true;
                    }
                    else
                    {
                        Properties.Settings.Default.DarkMode = false;
                    }
                    Properties.Settings.Default.Save();
                    RecMainWindow.ConsoleTextBox.Text = ConsoleRequest[0] + " " + ConsoleRequest[1] + " set!";
                }

                else if (ConsoleRequest[1].Equals("Exit", StringComparison.OrdinalIgnoreCase))
                {
                    Application.Current.Dispatcher.Invoke(Application.Current.Shutdown);
                }

                else if (ConsoleRequest[1].Equals("Restart", StringComparison.OrdinalIgnoreCase))
                {
                    MainWindow _MainWindow = new MainWindow();
                    _MainWindow.Show();
                    RecMainWindow.Close();
                }

                else
                {
                    RecMainWindow.ConsoleTextBox.Text = "Error: " + ConsoleRequest[1] + " dont exist.";
                }
            }
            catch
            {
                RecMainWindow.ConsoleTextBox.Text = "ERROR";
            }
        }

        void HelpScenario()
        {
            try
            {
                if (ConsoleRequest.Length == 1)
                {
                    RecMainWindow.ConsoleTextBox.Text = "Variants: Help App; Map;";
                }
                else if (ConsoleRequest[1].Equals("App", StringComparison.OrdinalIgnoreCase))
                {
                    
                    RecMainWindow.ConsoleTextBox.Text = "Variants: App Darkmode (t/f); App Restart; App Exit;";
                }
                else if (ConsoleRequest[1].Equals("Map", StringComparison.OrdinalIgnoreCase))
                {

                    RecMainWindow.ConsoleTextBox.Text = "Variants: Map AddCity (X) (Y) (Brush); Map AddCityByClick (Brush); Map AddPath (X0) (Y0) (X1) (Y1) (Brush); Map AddPathByClick (Brush); Map LoadProvince (ProvinceNum); Map ReloadProvince (ProvinceNum); Map ClearMap;";
                }


                else
                {
                    RecMainWindow.ConsoleTextBox.Text = "Error: " + ConsoleRequest[1] + " dont exist.";
                }
            }
            catch
            {
                RecMainWindow.ConsoleTextBox.Text = "ERROR";
            }
        }

        void MapScenario()
        {
            try
            {
                if(0 == 1)
                {

                }
                else
                {
                    RecMainWindow.ConsoleTextBox.Text = "Error: " + ConsoleRequest[1] + " dont exist.";
                }
            }
            catch
            {
                RecMainWindow.ConsoleTextBox.Text = "ERROR";
            }
        }
        
    }
}
