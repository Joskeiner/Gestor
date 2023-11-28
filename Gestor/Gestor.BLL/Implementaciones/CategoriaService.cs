using Gestor.BLL.Interfaces;
using Gestor.DAL.Interfaces;
using Gestor.ENTITY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.BLL.Implementaciones
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IGenericRepository<Categoria> _repository;
        public CategoriaService( IGenericRepository<Categoria> repository) 
        {
            _repository = repository;
        }
        public async Task<Categoria> Crear(Categoria entidad)
        {
            try
            {
                Categoria categoria = await _repository.Crear(entidad);

                if (categoria.Id == 0)
                    throw new TaskCanceledException("No se pudo crear la Categoria ");

                return categoria;

            }
            catch
            {
                throw;
            }
        }

        public async Task<Categoria> Editar(Categoria entidad)
        {
            try
            {
                Categoria buscarCategoria = await _repository.Obtener(p => p.Id == entidad.Id);

                buscarCategoria.Descripcion = entidad.Descripcion;
                buscarCategoria.EsActivo = entidad.EsActivo;

                bool respuesta = await _repository.Editar(buscarCategoria);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo editar la Categoria ");

                return buscarCategoria;

            }
            catch
            {
                throw;
            }
        } 

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                Categoria eliminarCategoria  = await _repository.Obtener(p => p.Id == id);

                if (eliminarCategoria == null)
                    throw new TaskCanceledException("La categoria que desea eliminar no existe  ");

                bool respuesta = await _repository.Delete(eliminarCategoria);

                return respuesta;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Categoria>> Lista()
        {
            IQueryable<Categoria> query = await _repository.Consultar();

            return query.ToList();
        }
    }
}
