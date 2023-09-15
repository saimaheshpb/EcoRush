using System;
using System.Collections.Generic;

namespace Proj_Ecorush.Models;

public partial class Afforestation
{
    public int ActivityId { get; set; }

    public string? EmailId { get; set; }

    public DateOnly ActivityDate { get; set; }

    public int Ccawarded { get; set; }

    public string Status { get; set; } = null!;

    public string PlantaionLoc { get; set; } = null!;

    public byte[]? Evidence { get; set; }

    public virtual Userinfo? Email { get; set; }
}
