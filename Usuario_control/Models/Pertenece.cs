using System;
using System.Collections.Generic;

namespace Usuario_control.Models;

public partial class Pertenece
{
    public string IdCurso { get; set; } = null!;

    public string CiAlumno { get; set; } = null!;

    public DateTime Gestion { get; set; }

    public virtual Alumno CiAlumnoNavigation { get; set; } = null!;

    public virtual Curso IdCursoNavigation { get; set; } = null!;
}
