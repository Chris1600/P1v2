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

namespace Project_Memory_Card_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int NR_OF_ROWS = 4;
        const int NR_OF_COLS = 4;
        MemoryGrid grid;
        
        public MainWindow(string txtinput1, string txtinput2)
        {
            InitializeComponent();
            grid = new MemoryGrid(GameGrid, NR_OF_ROWS, NR_OF_COLS, Label3, Label4);
            int playerscore1 = grid.score1;
            int playerscore2 = grid.score2;
            Label1.Content = txtinput1 + ": ";
            Label2.Content = txtinput2 + ": ";
            Label3.Content = playerscore1;
            Label4.Content = playerscore2;
        }

        //Reset on click
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            grid.Reset();
        }

        //Terug naar menu
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainMenu menu = new MainMenu();
            this.Close();
            menu.Show();
        }


        
    }


}
