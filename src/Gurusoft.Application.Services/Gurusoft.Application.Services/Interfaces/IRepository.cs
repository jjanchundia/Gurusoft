using System.Linq.Expressions;

namespace Gurusoft.Application.Services.Interfaces
{
    //Uso del patron de diseño Repository
    public interface IRepository<T> where T : class
    {
        Task Crear(T entidad);
        Task Modificar(T entidad);
        Task<IEnumerable<T>> ObtenerTodo();
        Task<T> ObtenerPorId(int id);
        Task<T> Filtrar(Expression<Func<T, bool>> predicate);
    }
}