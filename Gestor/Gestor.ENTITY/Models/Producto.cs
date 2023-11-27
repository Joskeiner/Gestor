using System;
using System.Collections.Generic;

namespace Gestor.ENTITY.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string? Codigobarra { get; set; }

    public string? Marca { get; set; }

    public string? Descripcion { get; set; }

    public int? Categoriaid { get; set; }

    public int? Stock { get; set; }

    public string? Urlimagen { get; set; }

    public string? Nombreimagen { get; set; }

    public decimal? Precio { get; set; }

    public bool? Esactivo { get; set; }

    public DateTime? Fecharegistro { get; set; }

    public virtual Categorium? Categoria { get; set; }

    public virtual ICollection<Detalleventum> Detalleventa { get; set; } = new List<Detalleventum>();
}
