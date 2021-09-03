using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoRutas.Backend.Domain;
using InfoRutas.Backend.DTOs;
using InfoRutas.Backend.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace InfoRutas.Backend.Controllers
{
    [Route("api/[controller]")]
    public class ComentariosController : Controller
    {
        private readonly ILogger<ComentariosController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ComentariosController(ILogger<ComentariosController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Comentarios/tramo/5
        [HttpGet("tramo/{tramoId}")]
        public async Task<ActionResult<IEnumerable<ComentarioDTO>>> GetAllByTramoId(int tramoId)
        {
            var comentarios = await _unitOfWork.ComentarioRepository.GetAllAsync(t => t.TramoId == tramoId, r => r.OrderByDescending(x => x.Fecha));
            return Ok(comentarios.Select(x => new ComentarioDTO(x)));
        }

        // GET: api/Comentarios/pdi/5
        [HttpGet("pdi/{pdiId}")]
        public async Task<ActionResult<IEnumerable<ComentarioDTO>>> GetAllByPdiId(int pdiId)
        {
            var comentarios = await _unitOfWork.ComentarioRepository.GetAllAsync(c => c.PdiId == pdiId, r => r.OrderByDescending(x => x.Fecha));
            return Ok(comentarios.Select(x => new ComentarioDTO(x)));
        }

        // GET: api/Comentarios/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ComentarioDTO>> Get(int id)
        {
            var comentarios = await _unitOfWork.ComentarioRepository.GetAllAsync(r => r.Id == id, null, "Tramos");
            if (comentarios == null)
            {
                return NotFound();
            }

            var comentarioDTO = new ComentarioDTO(comentarios.FirstOrDefault());
            return Ok(comentarioDTO);
        }

        // PUT: api/Comentarios
        [HttpPost]
        public async Task<ActionResult> Post(ComentarioDTO dto)
        {
            var comentario = new Comentario
            {
                Fecha = DateTime.Now,
                // Usuario =
                Texto = dto.Texto,
                PdiId = dto.PdiId,
                TramoId = dto.TramoId
            };

            try
            {
                var res = await _unitOfWork.ComentarioRepository.CreateAsync(comentario);
                await _unitOfWork.CompleteAsync();
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        // PUT api/Comentarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ComentarioDTO dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            var comentario = await _unitOfWork.ComentarioRepository.FindAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }

            comentario.Texto = dto.Texto;
            comentario.PdiId = dto.PdiId;
            comentario.TramoId = dto.TramoId;

            try
            {
                _unitOfWork.ComentarioRepository.Update(comentario);
                await _unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ComentarioExists(id))
            {
                return NotFound();
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }

            return NoContent();
        }

        // DELETE api/Comentarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var comentario = await _unitOfWork.ComentarioRepository.FindAsync(id);

            if (comentario == null)
            {
                return NotFound();
            }

            _unitOfWork.ComentarioRepository.Delete(comentario);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        private bool ComentarioExists(int id) =>
            _unitOfWork.ComentarioRepository.GetAll().Any(e => e.Id == id);

        private static ComentarioDTO ComentarioToDTO(Comentario comentario) =>
            new ComentarioDTO
            {
                Id = comentario.Id,
                Texto = comentario.Texto,
                Fecha = comentario.Fecha,
                PdiId = comentario.PdiId,
                TramoId = comentario.TramoId,
                UsuarioId = comentario.UsuarioId
            };
    }
}
