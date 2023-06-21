using System;
using System.Collections.Generic;

namespace Usuario_control.Models;

public partial class Notum
{
    public string CiAlumno { get; set; } = null!;

    public string CodigoAsignatura { get; set; } = null!;

    public DateTime Gestion { get; set; }

    public int Calificacion { get; set; }

    public string Periodo { get; set; } = null!;

    public string? Tipo { get; set; }

    public virtual Alumno CiAlumnoNavigation { get; set; } = null!;

    public virtual Asignatura CodigoAsignaturaNavigation { get; set; } = null!;
}
