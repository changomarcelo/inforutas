using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using InfoRutas.Backend.Domain;

namespace InfoRutas.Backend.DTOs
{
    public class RutaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Numero { get; set; }
        public string Jurisdiccion { get; set; } // Códigos según ISO 3166
        //public int Longitud { get; set; }

        public RutaDTO(Ruta ruta)
        {
            Id = ruta.Id;
            Nombre = ruta.Nombre;
            Descripcion = ruta.Descripcion;
            Numero = ruta.Numero;
            Jurisdiccion = ruta.Jurisdiccion;
            //Longitud = ruta.Longitud;
        }

        [JsonConstructor]
        public RutaDTO() { }
    }
}