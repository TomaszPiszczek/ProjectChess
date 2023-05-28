using System;
using System.Collections.Generic;

namespace ProjectChess.DBConnection;

public partial class Match
{
    public int Id { get; set; }

    public int Player1Id { get; set; }

    public int Player2Id { get; set; }

    public DateTime Date { get; set; }

    public string Result { get; set; } = null!;

    public virtual Player Player1 { get; set; } = null!;

    public virtual Player Player2 { get; set; } = null!;
}
