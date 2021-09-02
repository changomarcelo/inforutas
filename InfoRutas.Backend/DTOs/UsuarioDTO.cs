using System;
using System.Security.Cryptography;
using System.Text;

namespace InfoRutas.Backend.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool Activo { get; set; }
        public int Nivel { get; set; }

        public UsuarioDTO(int id, string nombre, string email, string passwordHash, int nivel)
        {
            Id = id;
            Nombre = nombre ?? throw new ArgumentNullException(nameof(email));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Activo = true;
            if (nivel > 3) throw new ArgumentException("El nivel máximo es 3", nameof(nivel));
            Nivel = nivel;
            PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));
        }
    }
}
