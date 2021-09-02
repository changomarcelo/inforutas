using System;
using System.Collections.Generic;
using InfoRutas.Backend.Domain;

namespace InfoRutas.Backend.DTOs
{
    public class TramoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Orden { get; set; }
        public string Informe { get; set; }
        public DateTime FechaInforme { get; set; }

        public List<PdiDTO> PDIs { get; set; }

        public TramoDTO(Tramo tramo)
        {
            Id = tramo.Id;
            Nombre = tramo.Nombre;
            Orden = tramo.Orden;
            Informe = tramo.Informe;
            FechaInforme = tramo.FechaInforme;

            PDIs = new List<PdiDTO>();

            foreach (var pdi in tramo.PDIs)
            {
                var pdiDTO = new PdiDTO(pdi);
                PDIs.Add(pdiDTO);
            }
        }
    }
}
