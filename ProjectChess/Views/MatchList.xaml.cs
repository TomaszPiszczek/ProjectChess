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

namespace ProjectChess.Views
{
    /// <summary>
    /// Logika interakcji dla klasy MatchList.xaml
    /// </summary>
    public partial class MatchList : UserControl
    {
        public MatchList()
        {
            InitializeComponent();
            using (ChessContext db = new ChessContext())
            {
                List<Match> list = db.Matches.ToList();
                foreach (Match match in list)
                {
                    match.Zawodnik1 = db.Player.FirstOrDefault(a => a.Id == match.Player1Id)?.Name ?? "brak";
                }
                foreach (Match match in list)
                {
                    match.Zawodnik2 = db.Player.FirstOrDefault(a => a.Id == match.Player2Id)?.Name ?? "brak";
                }
                gridPlayer.ItemsSource = list;
            }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddPlayer page = new AddPlayer();
            page.ShowDialog();
            using (ChessContext db = new ChessContext())
            {
                List<Player> list = db.Player.ToList();
                gridPlayer.ItemsSource = list;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Player player = (Player)gridPlayer.SelectedItem;
            AddPlayer page = new AddPlayer();
            page.player = player;
            page.ShowDialog();
            using (ChessContext db = new ChessContext())
            {

                gridPlayer.ItemsSource = db.Player.ToList();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Player model = (Player)gridPlayer.SelectedItem;
            if (model != null && model.Id != 0)
            {
                if (MessageBox.Show("Czy usunąć zawodnika?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    ChessContext db = new ChessContext();
                    List<Player> players = db.Player.Where(x => x.Id == model.Id).ToList();
                    foreach (var item in players)
                    {
                        db.Player.Remove(item);
                    }
                    Player player = db.Player.Find(model.Id);
                    db.Player.Remove(player);
                    db.SaveChanges();
                    MessageBox.Show("Usunięto");
                    gridPlayer.ItemsSource = db.Player.ToList();
                }
            }

        }
    }
}
