using System;
using System.Collections.Generic;

namespace Usuario_control.Models;

public partial class Pago
{
    public string Id { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string? Detalle { get; set; }
}
