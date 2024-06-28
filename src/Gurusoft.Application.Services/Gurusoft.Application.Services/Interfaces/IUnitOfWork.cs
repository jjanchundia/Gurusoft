using Gurusoft.Domain;

namespace Gurusoft.Application.Services.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<NumeroPrimo> NumeroPrimoRepository { get; }
        IRepository<Usuario> UsuarioRepository { get; }
        Task<int> SaveChangesAsync();
    }
}