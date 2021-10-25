using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoRutas.Backend.Domain;
using InfoRutas.Backend.DTOs;
using InfoRutas.Backend.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InfoRutas.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TramosController : ControllerBase
    {
        private readonly ILogger<RutasController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public TramosController(ILogger<RutasController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Tramos/ruta/5
        [HttpGet("ruta/{rutaId}")]
        public async Task<ActionResult<IEnumerable<TramoDTO>>> GetByRuta(int rutaId)
        {
            var rutas = await _unitOfWork.TramoRepository.GetAllAsync(t => t.RutaId == rutaId, t => t.OrderBy(t => t.Orden));
            return Ok(rutas.Select(x => new TramoDTO(x)));
        }

        // GET: api/Tramos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TramoDTO>> Get(int id)
        {
            var tramo = await _unitOfWork.TramoRepository.FindAsync(id);
            return Ok(new TramoDTO(tramo));
        }

        // PUT: api/Tramos
        [HttpPost]
        public async Task<ActionResult> Post(TramoDTO dto)
        {
            var tramo = new Tramo
            {
                Nombre = dto.Nombre,
                RutaId = dto.RutaId,
                Orden = dto.Orden,
                Informe = dto.Informe,
                FechaInforme = dto.FechaInforme
            };

            try
            {
                var res = await _unitOfWork.TramoRepository.CreateAsync(tramo);
                await _unitOfWork.CompleteAsync();
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        // PUT api/Tramos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TramoDTO dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            var tramo = await _unitOfWork.TramoRepository.FindAsync(id);
            if (tramo == null)
            {
                return NotFound();
            }

            tramo.Nombre = dto.Nombre;
            tramo.Informe = tramo.Informe;
            tramo.Orden = tramo.Orden;
            tramo.RutaId = tramo.RutaId;
            tramo.FechaInforme = tramo.FechaInforme;

            try
            {
                _unitOfWork.TramoRepository.Update(tramo);
                await _unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException) when (!TramoExists(id))
            {
                return NotFound();
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }

            return NoContent();
        }

        // DELETE api/Tramos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tramo = await _unitOfWork.TramoRepository.FindAsync(id);

            if (tramo == null)
            {
                return NotFound();
            }

            _unitOfWork.TramoRepository.Delete(tramo);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        private bool TramoExists(int id) =>
            _unitOfWork.TramoRepository.GetAll().Any(e => e.Id == id);
    }
}
