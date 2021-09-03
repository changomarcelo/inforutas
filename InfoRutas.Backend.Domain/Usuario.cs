using System;
using System.Security.Cryptography;
using System.Text;

namespace InfoRutas.Backend.Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool Activo { get; set; }
        public int Nivel { get; set; }

        public Usuario(int id, string nombre, string email, string passwordHash, int nivel)
        {
            this.Id = id;
            this.Nombre = nombre ?? throw new ArgumentNullException(nameof(email));
            this.Email = email ?? throw new ArgumentNullException(nameof(email));
            this.Activo = true;
            if (nivel > 3) throw new ArgumentException("El nivel máximo es 3", nameof(nivel));
            this.Nivel = nivel;
            this.PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));
        }

        public static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        public static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
        {
            // Hash the input.
            var hashOfInput = GetHash(hashAlgorithm, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0;
        }
    }
}
