using System;
using InfoRutas.Backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfoRutas.Backend.Repository.EntityConfigurations
{
    public class ComentarioConfiguration : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.Property(p => p.Fecha)
                .IsRequired(true);

            builder.HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Pdi)
                .WithMany()
                .HasForeignKey(c => c.PdiId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Tramo)
                .WithMany()
                .HasForeignKey(c => c.TramoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
