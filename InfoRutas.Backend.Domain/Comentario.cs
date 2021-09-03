using System;
using System.Collections.Generic;

namespace InfoRutas.Backend.Domain
{
    public class Comentario
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Texto { get; set; }
        public bool Aprobado { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int? PdiId { get; set; }
        public Pdi Pdi { get; set; }

        public int? TramoId { get; set; }
        public Tramo Tramo { get; set; }

        public Comentario(int id, DateTime fecha, string texto, int usuarioId, int? pdiId, int? tramoId, bool aprobado)
        {
            this.Id = id;
            this.Fecha = fecha;
            this.Texto = texto;
            this.UsuarioId = usuarioId;
            this.PdiId = pdiId;
            this.TramoId = tramoId;
            this.Aprobado = aprobado;
        }

        public Comentario() { }
    }
}
