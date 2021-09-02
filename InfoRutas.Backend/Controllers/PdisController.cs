using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoRutas.Backend.DTOs;
using InfoRutas.Backend.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET: api/tramo/
        [HttpGet("tramo/{tramoId}")]
        public async Task<ActionResult<IEnumerable<PdiDTO>>> GetByTramo(int tramoId)
        {
            var pdis = await _unitOfWork.PdiRepository.GetAllAsync(p => p.TramoId == tramoId, p => p.OrderBy(p => p.Orden));
            return Ok(pdis.Select(x => new PdiDTO(x)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PdiDTO>> Get(int id)
        {
            var pdi = await _unitOfWork.PdiRepository.GetByIdAsync(id);
            return Ok(new PdiDTO(pdi));
        }

    }
}
