using System;
using InfoRutas.Backend.Domain;

namespace InfoRutas.Backend.DTOs
{
    public class PdiDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public bool EsAporte { get; set; }
        public bool Inicio { get; set; }
        public bool Fin { get; set; }
        public bool Aprobado { get; set; }

        public int CategoriaId { get; set; }
        public CategoriaDTO Categoria { get; set; }

        public int TramoId { get; set; }
        public TramoDTO Tramo { get; set; }

        //public int UsuarioId { get; set; }
        //public UsuarioDTO Usuario { get; set; }

        public int Orden { get; set; }

        public PdiDTO(Pdi pdi)
        {
            Id = pdi.Id;
            Nombre = pdi.Nombre;
            Latitud = pdi.Latitud;
            Longitud = pdi.Longitud;
            EsAporte = pdi.EsAporte;
            Inicio = pdi.Inicio;
            Fin = pdi.Fin;
            CategoriaId = pdi.CategoriaId;
            TramoId = pdi.TramoId;
            Orden = pdi.Orden;
            Aprobado = pdi.Aprobado;
        }
    }
}
