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
    /// Logika interakcji dla klasy RankingList.xaml
    /// </summary>
    public partial class RankingList : UserControl
    {
        public RankingList()
        { 
                InitializeComponent();
                using (ChessContext db = new ChessContext())
                {
                    List<Player> list = db.Player.OrderByDescending(x=>x.Rank).ToList();
                    gridPlayer.ItemsSource = list;
                }
            
        }
    }
}
