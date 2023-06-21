using System;
using System.Collections.Generic;

namespace Usuario_control.Models;

public partial class Registra
{
    public string CiAlumno { get; set; } = null!;

    public string IdPago { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public decimal Total { get; set; }

    public string? Medio { get; set; }

    public virtual Alumno CiAlumnoNavigation { get; set; } = null!;

    public virtual Pago IdPago1 { get; set; } = null!;

    public virtual Asignatura IdPagoNavigation { get; set; } = null!;
}
