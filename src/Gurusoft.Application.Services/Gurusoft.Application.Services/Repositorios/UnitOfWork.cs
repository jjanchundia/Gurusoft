using Gurusoft.Application.Services.Interfaces;
using Gurusoft.Domain;
using Gurusoft.Persistencia;

namespace Gurusoft.Application.Services.Repositorios
{
    //Uso del patron de diseño UOW
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IRepository<NumeroPrimo> _numeroPrimoRepository;
        private IRepository<Usuario> _usuarioRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IRepository<NumeroPrimo> NumeroPrimoRepository
        {
            get { return _numeroPrimoRepository ??= new Repository<NumeroPrimo>(_context); }
        }

        public IRepository<Usuario> UsuarioRepository
        {
            get { return _usuarioRepository ??= new Repository<Usuario>(_context); }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}