using System;
using System.Collections.Generic;

namespace Usuario_control.Models;

public partial class Curso
{
    public string Id { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Grado { get; set; } = null!;

    public int? Aula { get; set; }

    public virtual ICollection<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();
}
