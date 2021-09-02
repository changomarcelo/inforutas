using System;
using System.Threading.Tasks;
using InfoRutas.Backend.Domain;

namespace InfoRutas.Backend.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Categoria> CategoriaRepository { get; }
        IRepository<Comentario> ComentarioRepository { get; }
        IRepository<Pdi> PdiRepository { get; }
        IRepository<Ruta> RutaRepository { get; }
        IRepository<Tramo> TramoRepository { get; }
        IRepository<Usuario> UsuarioRepository { get; }

        Task CompleteAsync();
        void Commit();
        void Rollback();
    }
}
