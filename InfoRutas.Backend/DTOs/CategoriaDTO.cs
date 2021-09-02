using System.Collections.Generic;

namespace InfoRutas.Backend.DTOs
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<PdiDTO> Pdis { get; set; }

        public CategoriaDTO(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
    }
}
