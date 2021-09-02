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

        public int Orden { get; set; }

        public Pdi(int id, string nombre, decimal latitud, decimal longitud, bool esAporte, bool inicio, bool fin, int categoriaId, int tramoId, int usuarioId, int orden)
        {
            Id = id;
            Nombre = nombre;
            Latitud = latitud;
            Longitud = longitud;
            EsAporte = esAporte;
            Inicio = inicio;
            Fin = fin;
            CategoriaId = categoriaId;
            TramoId = tramoId;
            UsuarioId = usuarioId;
            Orden = orden;
        }
    }
}
