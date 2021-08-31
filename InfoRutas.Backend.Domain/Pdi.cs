using System;

namespace InfoRutas.Backend.Domain
{
    public class Pdi
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public bool EsAporte { get; set; }
        public bool Inicio { get; set; }
        public bool Fin { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public int TramoId { get; set; }
        public Tramo Tramo { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public Pdi()
        {
        
        }
    }
}
