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

        }
    }
}
