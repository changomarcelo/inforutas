using System;
using InfoRutas.Backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfoRutas.Backend.Repository.EntityConfigurations
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.Property(p => p.Nombre)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.HasData(
                new Categoria(1, "Localidades"),
                new Categoria(2, "Estaciones de Servicio"),
                new Categoria(3, "Paradores"),
                new Categoria(4, "Áreas de descanso"),
                new Categoria(5, "Restaurantes"),
                new Categoria(6, "Miradores"),
                new Categoria(7, "Sitios turísticos"),
                new Categoria(8, "Baños"),
                new Categoria(9, "Alojamientos"),
                new Categoria(10, "Peajes"),
                new Categoria(11, "Aportes")
                );
        }
    }
}
