﻿using System.Windows;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SQLServer sqlserver = new SQLServer();
        public MainWindow()
        {
            InitializeComponent();
            hamburgerMenu.Visibility = Visibility.Collapsed;
            openHamburgerMenuBtn.Visibility = Visibility.Collapsed;
            Main.Content = new LoginPage(Main, sqlserver);
        }

        private void closeHamburgerMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            if (hamburgerMenu.Visibility != Visibility.Collapsed)
            {
                hamburgerMenu.Visibility = Visibility.Collapsed;
            }
        }

        private void openHamburgerMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            if (hamburgerMenu.Visibility == Visibility.Collapsed)
            {
                hamburgerMenu.Visibility = Visibility.Visible;
            }
        }

        private void homepageBtn_Click(object sender, RoutedEventArgs e)
        {
            // MAIN NEEDS TO GET DOCTOR CLASS SO IT CAN PUSH IT WHEN OPENING WINDOW
            Main.Content = new homePage(sqlserver, sqlserver.doctor);
            hamburgerMenu.Visibility = Visibility.Collapsed;
        }

        private void patientOverzichtBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new patientOverzicht();
            hamburgerMenu.Visibility = Visibility.Collapsed;
        }

        private void patientToevoegenBtn_Click(object sender, RoutedEventArgs e)
        {

            hamburgerMenu.Visibility = Visibility.Collapsed;
        }

        private void instellingBtn_Click(object sender, RoutedEventArgs e)
        {

            hamburgerMenu.Visibility = Visibility.Collapsed;
        }

        private void helpBtn_Click(object sender, RoutedEventArgs e)
        {

            hamburgerMenu.Visibility = Visibility.Collapsed;
        }

        private void Main_ContentRendered(object sender, EventArgs e)
        {
            if (Main.Content.ToString() != "Design_test.LoginPage")
            {
                openHamburgerMenuBtn.Visibility = Visibility.Visible;
            }
        }
    }
}
