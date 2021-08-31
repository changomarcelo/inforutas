using System;
using InfoRutas.Backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfoRutas.Backend.Repository.EntityConfigurations
{
    public class TramoConfiguration : IEntityTypeConfiguration<Tramo>
    {
        public void Configure(EntityTypeBuilder<Tramo> builder)
        {
            builder.Property(p => p.Nombre)
                .IsRequired(true)
                .HasMaxLength(100);

            builder.HasOne(t => t.Ruta)
                .WithMany(r => r.Tramos)
                .HasForeignKey(t => t.RutaId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
