using System;
using System.Collections.Generic;

namespace ProjectChess.DBConnection;

public partial class Player
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public int Rank { get; set; }

    public DateTime Date { get; set; }

    public int AdressId { get; set; }

    public virtual Adress Adress { get; set; } = null!;

    public virtual ICollection<Match> MatchPlayer1s { get; set; } = new List<Match>();

    public virtual ICollection<Match> MatchPlayer2s { get; set; } = new List<Match>();
}
