using System;
using System.Collections.Generic;

namespace Gestor.ENTITY.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string? CodigoBarra { get; set; }

    public string? Marca { get; set; }

    public string? Descripcion { get; set; }

    public int? Categoriaid { get; set; }

    public int? Stock { get; set; }

    public string? UrlImagen { get; set; }

    public string? NombreImagen { get; set; }

    public decimal? Precio { get; set; }

    public bool? Esactivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Categoria? Categoria { get; set; }

    public virtual ICollection<DetalleVenta> DetallEventa { get; set; } = new List<DetalleVenta>();
}
