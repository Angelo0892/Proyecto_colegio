using System;
using System.Collections.Generic;

namespace Usuario_control.Models;

public partial class Profesor
{
    public string Ci { get; set; } = null!;

    public string Profecion { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string ApellidoP { get; set; } = null!;

    public string ApellidoM { get; set; } = null!;

    public string Domicilio { get; set; } = null!;

    public int Celular { get; set; }

    public decimal Sueldo { get; set; }

    public string CorreoE { get; set; } = null!;

    public string? Observaciones { get; set; }
}
