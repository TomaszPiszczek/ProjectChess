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
    public partial class AddPlayer : Window
    {
        public AddPlayer()
        {
            InitializeComponent();
            using (ChessContext db = new ChessContext())
            {
                List<Adress> addresses = db.Adresses.ToList();
                countryComboBox.ItemsSource = addresses;
                countryComboBox.DisplayMemberPath = "Country";
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public Player player;
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text.Trim() == "" || surname.Text.Trim() =="" || rank.Text.Trim() == "")
            {
                MessageBox.Show("IUzupełnij wszystkie pola");
            }
            else {
            using(ChessContext db = new ChessContext())
                {
                    if(player != null && player.Id !=0) 
                    {
                        Player update = new Player();
                        update.Id = player.Id;
                        update.Name = name.Text;
                        update.Surname = surname.Text;
                        try
                        {
                            update.Rank = int.Parse(rank.Text);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ranking musi być liczbą");
                        }

                        DateTime selectedDate = birthday.SelectedDate ?? DateTime.Now;
                        update.Date = selectedDate;

                        if (countryComboBox.SelectedItem is Adress selectedAddress)
                        {
                            update.CountryId = selectedAddress.Id;
                        }
                        else
                        {
                            MessageBox.Show("Wybierz kraj");
                            return;
                        }


                        db.Player.Update(update);
                        db.SaveChanges();
                        MessageBox.Show("Pomyslnie zaktualizowano" + update.Id + update.Name + update.Surname);

                    }
                    else
                    {
                        Player player = new Player();
                        player.Name = name.Text;
                        player.Surname = surname.Text;
                        try
                        {
                            player.Rank = int.Parse(rank.Text);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ranking musi być liczbą");
                        }
                        DateTime selectedDate = birthday.SelectedDate ?? DateTime.Now;
                        player.Date = selectedDate;
                       

                        if (countryComboBox.SelectedItem is Adress selectedAddress)
                        {
                            player.CountryId = selectedAddress.Id;
                        }
                        else
                        {
                            MessageBox.Show("Wybierz kraj");
                            return;
                        }
                        db.Player.Add(player);
                        db.SaveChanges();
                        MessageBox.Show("Dodano zawodnika ");

                    }
                   
                }
            }
            
        }

        private void ChessMainwindow_Loaded(object sender, RoutedEventArgs e)
        {
            if(player!= null && player.Id != 0)
            {
                name.Text = player.Name;
                surname.Text = player.Surname;

                rank.Text = player.Rank.ToString();
                birthday.SelectedDate = Convert.ToDateTime(player.Date);

                countryComboBox.SelectedItem = player.CountryId;
            }
        }
    }
}
