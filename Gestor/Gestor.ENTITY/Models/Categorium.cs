using System;
using System.Collections.Generic;

namespace Gestor.ENTITY.Models;

public partial class Categorium
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public bool? Esactivo { get; set; }

    public DateTime? Fecharegistro { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
