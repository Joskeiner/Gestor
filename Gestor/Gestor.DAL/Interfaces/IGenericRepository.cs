using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Obtener(Expression<Func<T, bool>> filtro);
        Task<IQueryable<T>> Consultar(Expression<Func<T, bool>> filtro = null);

        Task<T> Crear(T entidad);
        Task<bool> Editar(T entidad);
        Task<bool> Delete(T entidad);
    }
}
