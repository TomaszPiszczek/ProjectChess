using System;
using System.Collections.Generic;

namespace ProjectChess.DBConnection;

public partial class Adress
{
    public int Id { get; set; }

    public string Country { get; set; } = null!;

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
