using Concessionaria.Models;
using Microsoft.EntityFrameworkCore;

namespace Concessionaria.Contexts
{
    public class ConcessionariaContext : DbContext
    {
        public ConcessionariaContext(DbContextOptions<ConcessionariaContext> opts) : base(opts) { }

        public DbSet<Carro> Carros => Set<Carro>();
        public DbSet<Marca> Marcas => Set<Marca>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Carro>().HasOne(m => m.Marca).WithMany(c => c.Carros).HasForeignKey(m => m.MarcaId);

            builder.Entity<Marca>().HasMany(c => c.Carros).WithOne(m => m.Marca).HasForeignKey(m => m.MarcaId);
        }
    }
}
