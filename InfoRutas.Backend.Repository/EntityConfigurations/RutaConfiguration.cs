using System;
using InfoRutas.Backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfoRutas.Backend.Repository.EntityConfigurations
{
    public class RutaConfiguration : IEntityTypeConfiguration<Ruta>
    {
        public void Configure(EntityTypeBuilder<Ruta> builder)
        {
            builder.ToTable("ruta");

            builder.Property(p => p.Nombre)
                .IsRequired(true)
                .HasMaxLength(100);

            builder.HasIndex(p => new { p.Numero, p.Jurisdiccion }).IsUnique();

            builder.HasData(
                new Ruta(1,
                    "Ruta Nacional 40",
                    "La Ruta Nacional Nº 40 «Libertador General Don José de San Martín»1 es una carretera de Argentina cuyo recorrido se extiende desde el cabo Vírgenes, Santa Cruz hasta el límite con Bolivia en la ciudad de La Quiaca, en Jujuy.",
                    40,
                    "AR",
                    5194)
            );
        }
    }
}
