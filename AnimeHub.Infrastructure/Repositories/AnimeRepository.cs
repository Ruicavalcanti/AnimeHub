using AnimeHub.Domain.Abstractions;
using AnimeHub.Domain.Entities;
using AnimeHub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
namespace AnimeHub.Infrastructure.Repositories
{
    public class AnimeRepository : IAnimeRepository
    {
        protected readonly AppDbContext _db;

        public AnimeRepository(AppDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Adicionar Um anime na base de dados
        /// </summary>
        /// <param name="anime"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>        
        public async Task<Anime> AddAnime(Anime anime)
        {
            if (anime == null)
            {
                throw new ArgumentNullException(nameof(anime));
            }
            await _db.Animes.AddAsync(anime);
            return anime;
        }

        /// <summary>
        /// Buscar um anime Por Id
        /// </summary>
        /// <param name="animeId"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<Anime> GetAnimeById(int animeId)
        {
            var anime = await _db.Animes.FindAsync(animeId);
            if (anime == null)
            {
                throw new InvalidOperationException("Anime não Encontrado");
            }
            return anime;
        }

        /// <summary>
        /// Buscar todos os Animes com paginação. Trazendo de 10 em 10
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Anime>> GetAnimes(int pageNumber = 1,
            int pageSize = 10)
        {
            var query = _db.Animes.AsQueryable();
            query = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
            var animes = await query.ToListAsync();
            return animes ?? Enumerable.Empty<Anime>();
        }

        /// <summary>
        /// Busca anime especifico aplicando filtros opcionais
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nome"></param>
        /// <param name="diretor"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Anime>> GetAnimeByFilter(int? id = null, string? nome = null, string? diretor = null)
        {
            var query = BuildFilteredQuery(id, nome, diretor);
            var result = await query.ToListAsync();
            return result;
        }

        /// <summary>
        /// Constroi o IQueryable com os filtros opcionais.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nome"></param>
        /// <param name="diretor"></param>
        /// <returns></returns>
        private IQueryable<Anime> BuildFilteredQuery(int? id, string? nome, string? diretor)
        {
            var query = _db.Animes.AsQueryable();

            if (!id.HasValue && string.IsNullOrWhiteSpace(nome) && string.IsNullOrWhiteSpace(diretor))
                return query.Where(a => false);

            if (id.HasValue)
                query = query.Where(a => a.Id == id.Value);

            if (!string.IsNullOrWhiteSpace(nome))
                query = query.Where(a => a.Nome.Contains(nome));

            if (!string.IsNullOrWhiteSpace(diretor))
                query = query.Where(a => a.Diretor.Contains(diretor));

            return query;
        }

        /// <summary>
        /// Alterar Anime
        /// </summary>
        /// <param name="anime"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void UpdateAnime(Anime anime)
        {
            if (anime == null)
                throw new ArgumentNullException(nameof(anime));
            _db.Animes.Update(anime);
        }
        /// <summary>
        /// Excluir Anime
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<Anime> DeleteAnime(int id)
        {
            var anime = await GetAnimeById(id);
            if (anime is null)
                throw new InvalidOperationException("Anime não Encontrado");
            _db.Animes.Remove(anime);
            return anime;
        }
    }
}
