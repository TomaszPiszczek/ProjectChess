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
using System.Windows.Shapes;

namespace ProjectChess
{
    /// <summary>
    /// Logika interakcji dla klasy AddPlayer.xaml
    /// </summary>
    public partial class AddMatch : Window
    {
        public AddMatch()
        {
            InitializeComponent();
            using (ChessContext db = new ChessContext())
            {
                List<Player> players = db.Player.ToList();
                countryComboBox1.ItemsSource = players;
                countryComboBox2.ItemsSource = players;
                countryComboBox1.DisplayMemberPath = "Surname";
                countryComboBox2.DisplayMemberPath = "Surname";
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public Player player;
        public Match match;
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            using(ChessContext db = new ChessContext())
                {
                Match update = new Match();

                // Ustawienie zawodników
                if (countryComboBox1.SelectedItem is Player selectedPlayer1)
                {
                    update.Player1Id = selectedPlayer1.Id;
                }

                if (countryComboBox2.SelectedItem is Player selectedPlayer2)
                {
                    update.Player2Id = selectedPlayer2.Id;
                }

                // Ustawienie daty
                DateTime selectedDate = date.SelectedDate ?? DateTime.Now;
                update.Date = selectedDate;

                // Ustawienie wyniku - przykładowo pobierając wartość z ComboBoxa
                //update.Result = resultComboBox.SelectedItem?.ToString();

                // Zapis do bazy danych
                db.Matches.Update(update);
                db.SaveChanges();

                MessageBox.Show("Pomyślnie zaktualizowano");

            }
                    
                   
                
            
        }

        private void ChessMainwindow_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

