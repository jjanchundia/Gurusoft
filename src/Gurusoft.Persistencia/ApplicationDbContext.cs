using Gurusoft.Domain;
using Microsoft.EntityFrameworkCore;

namespace Gurusoft.Persistencia
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<NumeroPrimo> NumeroPrimo { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NumeroPrimo>()
                .HasOne(p => p.Usuario)
                .WithMany(tp => tp.NumeroPrimo)
                .HasForeignKey(p => p.UsuarioId);
        }
    }
}