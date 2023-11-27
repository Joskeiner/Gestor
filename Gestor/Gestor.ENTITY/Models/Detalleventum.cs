using System;
using System.Collections.Generic;

namespace Gestor.ENTITY.Models;

public partial class Detalleventum
{
    public int Id { get; set; }

    public int? Ventaid { get; set; }

    public int? Productoid { get; set; }

    public string? Marcaproducto { get; set; }

    public string? Descripcionproducto { get; set; }

    public string? Categoriaproducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public decimal? Total { get; set; }

    public virtual Producto? Producto { get; set; }

    public virtual Ventum? Venta { get; set; }
}
