using System;
using System.Collections.Generic;

namespace Proj_Ecorush.Models;

public partial class Userinfo
{
    public string EmailId { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public string OfficeLocation { get; set; } = null!;

    public int CcPoints { get; set; }

    public string URole { get; set; } = null!;

    public virtual ICollection<Afforestation> Afforestations { get; set; } = new List<Afforestation>();

    public virtual ICollection<Carpooling> Carpoolings { get; set; } = new List<Carpooling>();

    public virtual ICollection<EvTravel> EvTravels { get; set; } = new List<EvTravel>();

    public virtual ICollection<WalkCycle> WalkCycles { get; set; } = new List<WalkCycle>();
}
