using System.Collections.Generic;

namespace InfoRutas.Backend.Domain
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public IEnumerable<Pdi> Pdis { get; set; }

        public Categoria(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }
    }
}
