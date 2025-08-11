using AnimeHub.Domain.Abstractions;
using AnimeHub.Infrastructure.Context;
namespace AnimeHub.Infrastructure.Repositories
{
    public class UnityOfWork : IUnitOfWork, IDisposable
    {
        private IAnimeRepository? _animeRepo;
        private readonly AppDbContext _context;

        public UnityOfWork(AppDbContext context)
        {
            _context = context;
        }        
        public IAnimeRepository AnimeRepository
        {
            get
            {
                return _animeRepo = _animeRepo ??
                    new AnimeRepository(_context);
            }
        }
        /// <summary>
        /// Salvar todos os métodos em um unico local
        /// </summary>
        /// <returns></returns>
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
