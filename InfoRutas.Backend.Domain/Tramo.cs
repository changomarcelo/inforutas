using System;
using System.Collections.Generic;

namespace InfoRutas.Backend.Domain
{
    public class Tramo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Orden { get; set; }
        public string Informe { get; set; }
        public DateTime FechaInforme { get; set; }

        public int RutaId { get; set; }
        public Ruta Ruta { get; set; }

        public IEnumerable<Pdi> PDIs { get; set; }

        public Tramo(int id, string nombre, int orden, string informe, DateTime FechaInforme, int rutaId)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Orden = orden;
            this.Informe = informe;
            this.RutaId = rutaId;
        }
    }
}
