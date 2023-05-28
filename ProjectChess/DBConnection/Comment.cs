using System;
using System.Collections.Generic;

namespace ProjectChess.DBConnection;

public partial class Comment
{
    public int Id { get; set; }

    public int? PartyId { get; set; }

    public string? Author { get; set; }

    public string? Context { get; set; }
}
