using Gestor.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Gestor.DAL;
using Microsoft.EntityFrameworkCore;

namespace Gestor.DAL.Implementaciones
{
     public class GenericRepository<T> :IGenericRepository<T> where T : class 
    {
        private readonly DbBitwiseTraining2Context _context;
        public GenericRepository(DbBitwiseTraining2Context context) {
            _context = context;
        
        }

        public  async Task<IQueryable<T>> Consultar(Expression<Func<T, bool>> filtro = null)
        {
            IQueryable<T> queryEntidad = filtro == null ?  _context.Set<T>() :  _context.Set<T>().Where(filtro);
            return  queryEntidad;
        }

        public async  Task<T> Crear(T entidad)
        {
            try
            {
                 _context.Set<T>().Add(entidad);
                await _context.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete(T entidad)
        {
            try
            {
                _context.Set<T>().Remove(entidad);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async  Task<bool> Editar(T entidad)
        {
            try
            {
                _context.Set<T>().Update(entidad);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<T> Obtener(Expression<Func<T, bool>> filtro)
        {
            try
            {
                T entidad = await _context.Set<T>().FirstOrDefaultAsync(filtro);
                return entidad;
            }
            catch
            {
                throw;
            }
        }
    }
}
