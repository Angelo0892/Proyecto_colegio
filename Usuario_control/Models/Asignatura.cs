using System;
using System.Collections.Generic;

namespace Usuario_control.Models;

public partial class Asignatura
{
    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string IdCurso { get; set; } = null!;

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();

    public virtual Curso IdCursoNavigation { get; set; } = null!;
}
