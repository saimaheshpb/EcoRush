using System;
using System.Collections.Generic;

namespace Proj_Ecorush.Models;

public partial class EvTravel
{
    public int ActivityId { get; set; }

    public string? EmailId { get; set; }

    public DateOnly ActivityDate { get; set; }

    public int Ccawarded { get; set; }

    public string Status { get; set; } = null!;

    public string StartLoc { get; set; } = null!;

    public string EndLoc { get; set; } = null!;

    public decimal Distance { get; set; }

    public byte[]? Evidence { get; set; }

    public virtual Userinfo? Email { get; set; }
}
