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
    /// Interaction logic for EndGame.xaml
    /// </summary>
    public partial class EndGame : Window
    {
        public EndGame()
        {
            InitializeComponent();
            EnterName.startgame.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainMenu mainmenu = new MainMenu();
            mainmenu.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow main = new MainWindow("","");
            main.Show();
        }
    }
}
