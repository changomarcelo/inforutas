using System;
using System.Threading.Tasks;
using InfoRutas.Backend.Domain;

namespace InfoRutas.Backend.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Ruta> RutaRepository { get; }
        IRepository<Tramo> TramoRepository { get; }

        Task CompleteAsync();
        void Commit();
        void Rollback();
    }
}
