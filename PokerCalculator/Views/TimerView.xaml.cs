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

namespace PokerCalculator {
    /// <summary>
    /// Interaction logic for TimerView.xaml
    /// </summary>
    public partial class TimerView : Page {

        public double timer { get; }

        public TimerView(Poker g) {
            InitializeComponent();

            timeBankCount.Text = g.timer.ToString();
        }

        private void timeBankBtn_Click(object sender, RoutedEventArgs e) {

        }
    }
}
