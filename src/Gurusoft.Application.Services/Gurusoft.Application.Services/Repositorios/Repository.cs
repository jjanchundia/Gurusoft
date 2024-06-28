using Microsoft.EntityFrameworkCore;
using Gurusoft.Application.Services.Interfaces;

namespace Gurusoft.Application.Services.Repositorios
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task Crear(T entidad)
        {
            await _dbSet.AddAsync(entidad);
        }

        public async Task Modificar(T entidad)
        {
            _dbSet.Update(entidad);
        }

        public async Task<IEnumerable<T>> ObtenerTodo()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> ObtenerPorId(int id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}