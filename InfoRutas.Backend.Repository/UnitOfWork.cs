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

        private IRepository<Categoria> _categoriaRepository;
        private IRepository<Comentario> _comentarioRepository;
        private IRepository<Pdi> _pdiRepository;
        private IRepository<Ruta> _rutaRepository;
        private IRepository<Tramo> _tramoRepository;
        private IRepository<Usuario> _usuarioRepository;

        public UnitOfWork(InfoRutasDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); ;
            _logger = loggerFactory.CreateLogger("logs");
        }

        public IRepository<Categoria> CategoriaRepository
        {
            get
            {
                return _categoriaRepository
                    ?? (_categoriaRepository = new Repository<Categoria>(_context, _logger));
            }
        }

        public IRepository<Comentario> ComentarioRepository
        {
            get
            {
                return _comentarioRepository
                    ?? (_comentarioRepository = new Repository<Comentario>(_context, _logger));
            }
        }

        public IRepository<Pdi> PdiRepository
        {
            get
            {
                return _pdiRepository
                    ?? (_pdiRepository = new Repository<Pdi>(_context, _logger));
            }
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

        public IRepository<Usuario> UsuarioRepository
        {
            get
            {
                return _usuarioRepository
                    ?? (_usuarioRepository = new Repository<Usuario>(_context, _logger));
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
