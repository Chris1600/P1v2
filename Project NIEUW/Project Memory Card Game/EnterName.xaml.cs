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
    /// Interaction logic for EnterName.xaml
    /// </summary>
    public partial class EnterName : Window
    {
        public EnterName()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow StartGame = new MainWindow(txtinput1.Text, txtinput2.Text);
            this.Hide();
            StartGame.Show();
        }
    }
}
