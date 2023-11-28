using System;
using System.Collections.Generic;

namespace Gestor.ENTITY.Models;

public partial class Venta
{
    public int Id { get; set; }

    public string? NumeroVenta { get; set; }

    public string? DocumentoCliente { get; set; }

    public string? NombreCliente { get; set; }

    public decimal? Total { get; set; }

    public DateTime? Fecharegistro { get; set; }

    public virtual ICollection<DetalleVenta> Detalleventa { get; set; } = new List<DetalleVenta>();
}
