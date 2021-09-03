using System;
using System.Collections.Generic;

namespace InfoRutas.Backend.Domain
{
    public class Ruta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Numero { get; set; }
        public string Jurisdiccion { get; set; } // Códigos según ISO 3166 (AR: Ruta Nacional de Argentina - AR-B: Ruta provincial de Prov. Buenos Aires)
        public int Longitud { get; set; }

        public IEnumerable<Tramo> Tramos { get; set; }

        public Ruta(int id, string nombre, string descripcion, int numero, string jurisdiccion, int longitud)
        {
            this.Id = id;
            this.Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            this.Descripcion = descripcion;
            this.Numero = numero;
            this.Jurisdiccion = jurisdiccion;
            this.Longitud = longitud;
        }

        public Ruta() { }
    }
}