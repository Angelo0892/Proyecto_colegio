using System;
using System.Collections.Generic;

namespace Usuario_control.Models;

public partial class FaltaAsistencium
{
    public string CiAlumno { get; set; } = null!;

    public string NroClase { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string ControlA { get; set; } = null!;

    public string? Justificacion { get; set; }

    public virtual Alumno CiAlumnoNavigation { get; set; } = null!;
}
