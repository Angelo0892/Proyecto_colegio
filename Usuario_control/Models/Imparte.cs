using System;
using System.Collections.Generic;

namespace Usuario_control.Models;

public partial class Imparte
{
    public string CiProfesor { get; set; } = null!;

    public string CodigoAsignatura { get; set; } = null!;

    public DateTime Gestion { get; set; }

    public virtual Profesor CiProfesorNavigation { get; set; } = null!;

    public virtual Asignatura CodigoAsignaturaNavigation { get; set; } = null!;
}
