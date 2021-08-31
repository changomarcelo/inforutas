using System;
using InfoRutas.Backend.Domain;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace InfoRutas.Backend.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly InfoRutasDbContext _context;
        private readonly ILogger _logger;

        private IRepository<Ruta> _rutaRepository;
        private IRepository<Tramo> _tramoRepository;

        public UnitOfWork(InfoRutasDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); ;
            _logger = loggerFactory.CreateLogger("logs");
        }

        public IRepository<Ruta> RutaRepository
        {
            get
            {
                return _rutaRepository
                    ?? (_rutaRepository = new Repository<Ruta>(_context, _logger));
            }
        }

        public IRepository<Tramo> TramoRepository
        {
            get
            {
                return _tramoRepository
                    ?? (_tramoRepository = new Repository<Tramo>(_context, _logger));
            }
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            _context.Dispose();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
