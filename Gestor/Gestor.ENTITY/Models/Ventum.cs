using System;
using System.Collections.Generic;

namespace Gestor.ENTITY.Models;

public partial class Ventum
{
    public int Id { get; set; }

    public string? Numeroventa { get; set; }

    public string? Documentocliente { get; set; }

    public string? Nombrecliente { get; set; }

    public decimal? Total { get; set; }

    public DateTime? Fecharegistro { get; set; }

    public virtual ICollection<Detalleventum> Detalleventa { get; set; } = new List<Detalleventum>();
}
