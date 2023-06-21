using System;
using System.Collections.Generic;

namespace Usuario_control.Models;

public partial class Horario
{
    public string Codigo { get; set; } = null!;

    public TimeSpan HoraIngreso { get; set; }

    public TimeSpan HoraSalida { get; set; }

    public string Dia { get; set; } = null!;

    public string CodigoAsignatura { get; set; } = null!;

    public virtual Asignatura CodigoAsignaturaNavigation { get; set; } = null!;
}
