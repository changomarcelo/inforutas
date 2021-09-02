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

            builder.HasData(
                new Tramo(1, "Buenos Aires - Junin", 1, "Autovía", DateTime.Now, 2),
                new Tramo(2, "Junin - San Luis", 2, "Ruta en buen estado", DateTime.Now, 2),
                new Tramo(3, "San Luis - Mendoza", 4, "Autovía en su mayor parte", DateTime.Now, 2),
                new Tramo(4, "Rio Gallegos - El Calafate", 1, "Ruta", DateTime.Now, 1),
                new Tramo(5, "El Calafate - Bariloche", 2, "Ruta", DateTime.Now, 1),
                new Tramo(6, "Bariloche - San Martín de los Andes", 3, "Ruta", DateTime.Now, 2),
                new Tramo(7, "San Martín de los Andes - Malargüe", 4, "Ruta", DateTime.Now, 2),
                new Tramo(8, "Malargüe - Mendoza", 5, "Ruta", DateTime.Now, 2),
                new Tramo(9, "Mendoza - La Quiaca", 6, "Ruta", DateTime.Now, 2)
                );

        }
    }
}
