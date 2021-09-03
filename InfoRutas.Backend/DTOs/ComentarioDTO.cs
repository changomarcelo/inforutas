using System;
using InfoRutas.Backend.Domain;

namespace InfoRutas.Backend.DTOs
{
    public class ComentarioDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Texto { get; set; }
        public bool Aprobado { get; set; }

        public int UsuarioId { get; set; }
        public UsuarioDTO Usuario { get; set; }

        public int? PdiId { get; set; }
        public PdiDTO Pdi { get; set; }

        public int? TramoId { get; set; }
        public TramoDTO Tramo { get; set; }

        public ComentarioDTO(Comentario c)
        {
            this.Id = c.Id;
            this.Fecha = c.Fecha;
            this.Texto = c.Texto;
            this.UsuarioId = c.UsuarioId;
            this.PdiId = c.PdiId;
            this.TramoId = c.TramoId;
            this.Aprobado = c.Aprobado;
        }

        public ComentarioDTO() { }
    }
}
