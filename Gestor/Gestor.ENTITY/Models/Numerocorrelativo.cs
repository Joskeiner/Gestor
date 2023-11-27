using System;
using System.Collections.Generic;

namespace Gestor.ENTITY.Models;

public partial class Numerocorrelativo
{
    public int Id { get; set; }

    public int? Ultimonumero { get; set; }

    public int? Cantidaddigitos { get; set; }

    public string? Gestion { get; set; }

    public DateTime? Fechaactualizacion { get; set; }
}
