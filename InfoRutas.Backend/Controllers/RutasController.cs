using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoRutas.Backend.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InfoRutas.Backend.DTOs;
using InfoRutas.Backend.Domain;
using Microsoft.EntityFrameworkCore;

namespace InfoRutas.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RutasController : ControllerBase
    {
        private readonly ILogger<RutasController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public RutasController(ILogger<RutasController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Rutas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RutaDTO>>> Get()
        {
            var rutas = await _unitOfWork.RutaRepository.GetAllAsync(null, r => r.OrderBy(x => x.Numero));
            return Ok(rutas.Select(x => new RutaDTO(x)));
        }

        // GET: api/Rutas/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<RutaDTO>> Get(int id)
        {
            var rutas = await _unitOfWork.RutaRepository.GetAllAsync(r => r.Id == id, null, "Tramos,Tramos.PDIs");
            if (rutas == null)
            {
                return NotFound();
            }

            var rutaDTO = new RutaDetalleDTO(rutas.FirstOrDefault<Ruta>());
            return Ok(rutaDTO);
        }

        // GET: api/Rutas/search/{termino}
        [HttpGet("search/{termino}")]
        public async Task<ActionResult<IEnumerable<RutaDTO>>> Search(string termino)
        {
            var rutas = await _unitOfWork.RutaRepository.GetAllAsync(r => r.Numero.ToString() == termino || r.Nombre.ToUpper().Contains(termino.ToUpper()), r => r.OrderBy(x => x.Numero));
            return Ok(rutas.Select(x => new RutaDTO(x)));
        }

        // PUT: api/Rutas
        [HttpPost]
        public async Task<ActionResult> Post(RutaDTO dto)
        {
            //TODO: validar duplicados número+jurisdicción
            if (_unitOfWork.RutaRepository.GetAll(r => r.Numero == dto.Numero && r.Jurisdiccion == dto.Jurisdiccion).Any())
            {
                return BadRequest(string.Format("Ruta duplicada. Ya existe una ruta Nº {0} para la jurisdicción {1}", dto.Numero, dto.Jurisdiccion));
            }

            var ruta = new Ruta
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Jurisdiccion = dto.Jurisdiccion,
                Numero = dto.Numero
            };

            try
            {
                var res = await _unitOfWork.RutaRepository.CreateAsync(ruta);
                await _unitOfWork.CompleteAsync();
                return Ok();
            }
            catch(Exception error)
            {
                return BadRequest(error);
            }
        }

        // PUT api/Rutas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, RutaDTO dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            var ruta = await _unitOfWork.RutaRepository.FindAsync(id);
            if (ruta == null)
            {
                return NotFound();
            }

            ruta.Nombre = dto.Nombre;
            ruta.Descripcion = dto.Descripcion;
            ruta.Numero = dto.Numero;
            ruta.Jurisdiccion = dto.Jurisdiccion;

            try
            {
                _unitOfWork.RutaRepository.Update(ruta);
                await _unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException) when (!RutaExists(id))
            {
                return NotFound();
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }

            return NoContent();
        }

        // DELETE api/Rutas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ruta = await _unitOfWork.RutaRepository.FindAsync(id);

            if (ruta == null)
            {
                return NotFound();
            }

            _unitOfWork.RutaRepository.Delete(ruta);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        private bool RutaExists(int id) =>
            _unitOfWork.RutaRepository.GetAll().Any(e => e.Id == id);

        private static RutaDTO RutaToDTO(Ruta ruta) =>
            new RutaDTO
            {
                Id = ruta.Id,
                Nombre = ruta.Nombre,
                Descripcion = ruta.Descripcion,
                Numero = ruta.Numero,
                Jurisdiccion = ruta.Jurisdiccion
            };
    }
}
