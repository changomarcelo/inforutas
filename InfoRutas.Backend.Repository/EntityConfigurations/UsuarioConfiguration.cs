using System;
using System.Security.Cryptography;
using InfoRutas.Backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfoRutas.Backend.Repository.EntityConfigurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(p => p.Nombre)
                .IsRequired(true)
                .HasMaxLength(100);

            builder.Property(p => p.Email)
                .IsRequired(true)
                .HasMaxLength(100);

            using (SHA256 sha256Hash = SHA256.Create())
            {
                var passwordHash = Usuario.GetHash(sha256Hash, "123456");

                builder.HasData(
                    new Usuario(1, "Marce", "marce@centraldev.com.ar", passwordHash, 1)
                );
            }
        }
    }
}
