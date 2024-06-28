using Gurusoft.Domain;

namespace Gurusoft.Application.Services.Interfaces
{
    //Uso del patron de diseño UOW
    public interface IUnitOfWork : IDisposable
    {
        IRepository<NumeroPrimo> NumeroPrimoRepository { get; }
        IRepository<Usuario> UsuarioRepository { get; }
        Task<int> SaveChangesAsync();
    }
}