using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MangoStrategy
{
    class ConsoleClass
    {
        MainWindow RecMainWindow;
        GamePage _GamePage;
        string[] ConsoleRequest;
        public void Recieved( MainWindow RecievedMainWindow, string RecievedConsoleRequest)
        {
            RecMainWindow = RecievedMainWindow;
            ConsoleRequest = RecievedConsoleRequest.Split(' ');
            Request();
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
                    RecMainWindow.ConsoleTextBox.Text = "Variants: Help App;";
                }
                else if (ConsoleRequest[1].Equals("App", StringComparison.OrdinalIgnoreCase))
                {
                    
                    RecMainWindow.ConsoleTextBox.Text = "Variants: App Darkmode (t/f); App Restart; App Exit;";
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
