using System;
using System.Collections.Generic;
using InfoRutas.Backend.Domain;

namespace InfoRutas.Backend.DTOs
{
    public class RutaDetalleDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Numero { get; set; }
        public string Jurisdiccion { get; set; } // Códigos según ISO 3166
        public int Longitud { get; set; }
        public List<TramoDTO> Tramos { get; set; }

        public RutaDetalleDTO()
        { }

        public RutaDetalleDTO(Ruta ruta)
        {
            Id = ruta.Id;
            Nombre = ruta.Nombre;
            Descripcion = ruta.Descripcion;
            Numero = ruta.Numero;
            Jurisdiccion = ruta.Jurisdiccion;
            Longitud = ruta.Longitud;
            Tramos = new List<TramoDTO>();

            foreach (var t in ruta.Tramos)
            {
                var tramoDTO = new TramoDTO(t);
                Tramos.Add(tramoDTO);
            }
        }
    }
}