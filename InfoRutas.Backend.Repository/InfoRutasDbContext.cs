using System;
using InfoRutas.Backend.Domain;
using Microsoft.EntityFrameworkCore;

namespace InfoRutas.Backend.Repository
{
    public class InfoRutasDbContext : DbContext
    {
        // the dbset property will tell ef core that we have
        // a table that needs to be created if doesnt exist
        public virtual DbSet<Ruta> Users { get; set; }

        public InfoRutasDbContext(DbContextOptions<InfoRutasDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EntityConfigurations.CategoriaConfiguration());
            modelBuilder.ApplyConfiguration(new EntityConfigurations.ComentarioConfiguration());
            modelBuilder.ApplyConfiguration(new EntityConfigurations.PdiConfiguration());
            modelBuilder.ApplyConfiguration(new EntityConfigurations.RutaConfiguration());
            modelBuilder.ApplyConfiguration(new EntityConfigurations.TramoConfiguration());
            modelBuilder.ApplyConfiguration(new EntityConfigurations.UsuarioConfiguration());
        }
    }
}
