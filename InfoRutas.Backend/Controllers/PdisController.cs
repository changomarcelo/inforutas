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
    public class PdisController : ControllerBase
    {
        private readonly ILogger<RutasController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public PdisController(ILogger<RutasController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Pdis/tramo/5
        [HttpGet("tramo/{tramoId}")]
        public async Task<ActionResult<IEnumerable<PdiDTO>>> GetByTramo(int tramoId)
        {
            var pdis = await _unitOfWork.PdiRepository.GetAllAsync(p => p.TramoId == tramoId, p => p.OrderBy(p => p.Orden));
            return Ok(pdis.Select(x => new PdiDTO(x)));
        }

        // GET: api/Pdis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PdiDTO>> Get(int id)
        {
            var pdi = await _unitOfWork.PdiRepository.FindAsync(id);
            return Ok(new PdiDTO(pdi));
        }

        // PUT: api/Pdis
        [HttpPost]
        public async Task<ActionResult> Post(PdiDTO dto)
        {
            var pdi = new Pdi
            {
                Nombre = dto.Nombre,
                Latitud = dto.Latitud,
                Longitud = dto.Longitud,
                EsAporte = dto.EsAporte,
                Inicio = dto.Inicio,
                Fin = dto.Fin,
                CategoriaId = dto.CategoriaId,
                TramoId = dto.TramoId
                //, UsuarioId = ?? // este dato debe salir de la sesión
            };

            try
            {
                var res = await _unitOfWork.PdiRepository.CreateAsync(pdi);
                await _unitOfWork.CompleteAsync();
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        // PUT api/Pdis/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PdiDTO dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            var pdi = await _unitOfWork.PdiRepository.FindAsync(id);
            if (pdi == null)
            {
                return NotFound();
            }

            pdi.Nombre = dto.Nombre;
            pdi.Latitud = dto.Latitud;
            pdi.Longitud = dto.Longitud;
            pdi.EsAporte = dto.EsAporte;
            pdi.Inicio = dto.Inicio;
            pdi.Fin = dto.Fin;
            pdi.CategoriaId = dto.CategoriaId;
            pdi.TramoId = dto.TramoId;

            try
            {
                _unitOfWork.PdiRepository.Update(pdi);
                await _unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException) when (!PdiExists(id))
            {
                return NotFound();
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }

            return NoContent();
        }

        // DELETE api/Pdis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pdi = await _unitOfWork.PdiRepository.FindAsync(id);

            if (pdi == null)
            {
                return NotFound();
            }

            _unitOfWork.PdiRepository.Delete(pdi);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        private bool PdiExists(int id) =>
            _unitOfWork.PdiRepository.GetAll().Any(e => e.Id == id);
    }
}
