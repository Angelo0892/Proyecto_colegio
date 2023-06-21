using System;
using System.Collections.Generic;

namespace Usuario_control.Models;

public partial class Tutor
{
    public string Ci { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string ApellidoP { get; set; } = null!;

    public string ApellidoM { get; set; } = null!;

    public string Parentesco { get; set; } = null!;

    public string Domicilio { get; set; } = null!;

    public int Celular { get; set; }

    public string CorreoE { get; set; } = null!;

    public string? Observaciones { get; set; }

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();
}
