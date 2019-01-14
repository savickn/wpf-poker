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

namespace PokerCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }


        private void Start_Poker(object sender, RoutedEventArgs e) {
            PokerWindow pw = new PokerWindow();
            pw.Show();
        }

        private void Start_Game(object sender, RoutedEventArgs e) {
            GameWindow pw = new GameWindow();
            pw.Show();
        }

        private void Create_Account(object sender, RoutedEventArgs e) {
            AccountWindow aw = new AccountWindow();
            aw.Show();
        }
    }
}
