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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MemoryGame1._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenWindow(object sender, RoutedEventArgs e)
        {
          //  SpeelScherm objSpeelScherm = new SpeelScherm();
          //  this.Visibility = Visibility.Hidden;
          //  objSpeelScherm.Show();
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            Matchinggame matchinggame = new Matchinggame();
            this.Visibility = Visibility.Hidden;
            matchinggame.Show();
        }
    }
}
