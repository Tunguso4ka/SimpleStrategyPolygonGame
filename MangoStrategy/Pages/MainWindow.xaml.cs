﻿using System;
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
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ChangeTheme();
        }

        void ChangeTheme()
        {
            if (Properties.Settings.Default.DarkMode == true)
            {
                this.Background = Brushes.Black;
                InfoBtn.Style = (Style)FindResource("TabBarBtnDark");
                MiniBtn.Style = (Style)FindResource("TabBarBtnDark");
                MaxiBtn.Style = (Style)FindResource("TabBarBtnDark");
                CloseBtn.Style = (Style)FindResource("TabBarBtnDark");
                BackBtn.Style = (Style)FindResource("TabBarBtnDark");
                ShowConsoleBtn.Style = (Style)FindResource("TabBarBtnDark");
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button ClickedButton = (Button)sender;
            if ((string)ClickedButton.Tag == "Info")
            {
                try
                {
                    //_InfoWindow.Show();
                    //_InfoWindow.WindowState = WindowState.Normal;
                }
                catch
                {

                }
            }
            else if ((string)ClickedButton.Tag == "Minimize")
            {
                this.WindowState = WindowState.Minimized;
            }
            else if ((string)ClickedButton.Tag == "Maximize")
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                    MaxiBtn.Content = "";
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    MaxiBtn.Content = "";
                }
            }
            else if ((string)ClickedButton.Tag == "Close")
            {
                if (Properties.Settings.Default.AppCanBeClosed == true)
                {
                    Application.Current.Dispatcher.Invoke(Application.Current.Shutdown);
                }
            }
            else if ((string)ClickedButton.Tag == "Back")
            {
                if (Frame0.CanGoBack)
                {
                    Frame0.GoBack();
                }

            }
            else if ((string)ClickedButton.Tag == "ShowConsole")
            {
                if(ConsoleGrid.Visibility != Visibility.Visible)
                {
                    ConsoleGrid.Visibility = Visibility.Visible;
                }
                else
                {
                    ConsoleGrid.Visibility = Visibility.Collapsed;
                }
            }
            else if ((string)ClickedButton.Tag == "ClearConsole")
            {
                ConsoleTextBox.Text = "";
            }
            else if ((string)ClickedButton.Tag == "EnterConsole")
            {
                
            }
        }
    }
}