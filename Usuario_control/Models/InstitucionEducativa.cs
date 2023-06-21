using System;
using System.Collections.Generic;

namespace Usuario_control.Models;

public partial class InstitucionEducativa
{
    public string CodigoRue { get; set; } = null!;

    public string NombreRs { get; set; } = null!;

    public DateTime FechaFun { get; set; }

    public string Direccion { get; set; } = null!;

    public string Contactos { get; set; } = null!;

    public string Email { get; set; } = null!;
}
