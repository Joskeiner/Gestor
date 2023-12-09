namespace Gestor.APP.Models.ViewModels
{
    public class VMProducto
    {
        public int Id { get; set; } 

        public string? CodigoBarra { get; set; }    

        public string? Marca{ get; set;}

        public string? Descipcion { get; set;}

        public int? CategoriaId { get; set; }

        public string? NombreCategoria { get; set; }    

        public int? Stock { get; set; }

        public string? UrlImagen { get; set;}

        public string? Precio { get; set; }

        public int? EsActivo { get; set; }
    }
}
