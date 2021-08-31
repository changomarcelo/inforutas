using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoRutas.Backend.Domain;
using InfoRutas.Backend.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InfoRutas.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RutasController : ControllerBase
    {
        private readonly ILogger<RutasController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public RutasController(ILogger<RutasController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var rutas = _unitOfWork.RutaRepository.GetAll();
            return Ok(rutas);
        }
    }
}
