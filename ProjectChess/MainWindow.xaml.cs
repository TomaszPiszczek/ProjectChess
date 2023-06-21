using ProjectChess.DBConnection;
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
using ProjectChess.ViewModels;

namespace ProjectChess
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

        private void btnRanking_Click(object sender, RoutedEventArgs e)
        {
            lblWindowName.Content = "Ranking List";
            DataContext = new RankingViewModel();
        }

        private void btnPlayers_Click(object sender, RoutedEventArgs e)
        {
            lblWindowName.Content = "Player List";
            DataContext = new PlayerViewModel();
        }
    }
}
