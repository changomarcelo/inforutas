using System;
using InfoRutas.Backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfoRutas.Backend.Repository.EntityConfigurations
{
    public class PdiConfiguration : IEntityTypeConfiguration<Pdi>
    {
        public void Configure(EntityTypeBuilder<Pdi> builder)
        {
            builder.Property(p => p.Nombre)
                .IsRequired(true)
                .HasMaxLength(100);

            builder.HasOne(x => x.Tramo)
                .WithMany(x => x.PDIs)
                .HasForeignKey(x => x.TramoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Pdi(1, "La Quiaca", 0, 0, false, true, false, 1, 9, 1, 1, true),
                new Pdi(2, "Rio Gallegos", 0, 0, false, false, true, 1, 9, 1, 2, true)
             );
        }
    }
}
