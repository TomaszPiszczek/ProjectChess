using System;
using System.Collections.Generic;

namespace ProjectChess.DBConnection;

public partial class Player
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public int Rank { get; set; }
    public int Age
    {
        get
        {
            DateTime today = DateTime.Today;
            int age = today.Year - Date.Year;
            if (today < Date.AddYears(age))
                age--;

            return age;
        }
    }

    public DateTime Date { get; set; }
   
    public int CountryId { get; set; }

    public virtual Adress Adress { get; set; } = null!;

    public virtual ICollection<Match> MatchPlayer1s { get; set; } = new List<Match>();

    public virtual ICollection<Match> MatchPlayer2s { get; set; } = new List<Match>();
}
