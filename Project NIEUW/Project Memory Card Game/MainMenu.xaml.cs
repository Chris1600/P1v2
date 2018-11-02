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
using System.Windows.Shapes;

namespace Project_Memory_Card_Game
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
          InitializeComponent();
        }

        //Quit button
        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Start game
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            EnterName start = new EnterName();
            start.Show();
        }

        //Settings
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Settings settings = new Settings();
            settings.Show();
        }
    }
}
