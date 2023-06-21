using System;
using System.Collections.Generic;

namespace Usuario_control.Models;

public partial class Alumno
{
    public string Ci { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string ApellidoP { get; set; } = null!;

    public string ApellidoM { get; set; } = null!;

    public DateTime FechaNac { get; set; }

    public string Genero { get; set; } = null!;

    public DateTime AnoIngreso { get; set; }

    public string? Observaciones { get; set; }

    public string CiTutor { get; set; } = null!;

    public virtual Tutor CiTutorNavigation { get; set; } = null!;
}
