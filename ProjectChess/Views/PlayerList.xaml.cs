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
    /// Logika interakcji dla klasy PlayerList.xaml
    /// </summary>
    public partial class PlayerList : UserControl
    {
        public PlayerList()
        {
            InitializeComponent();
            using(ChessContext db = new ChessContext())
            {
                List<Player> list =db.Players.ToList();
                gridPlayer.ItemsSource = list;
            }
        }
    }
}
