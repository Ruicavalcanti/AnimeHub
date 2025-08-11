using AnimeHub.Domain.Abstractions;
using AnimeHub.Domain.Entities;
namespace AnimeHub.Tests.Unit.Fakes
{
    public class FakeAnimeRepository : IAnimeRepository
    {
        public List<Anime> Animes { get; } = new();

        public Task<Anime> AddAnime(Anime anime)
        {
            Animes.Add(anime);
            return Task.FromResult(anime);
        }

        public Task<Anime?> DeleteAnime(int id)
        {
            var anime = Animes.Find(a => a.Id == id);
            if (anime != null) Animes.Remove(anime);
            return Task.FromResult(anime);
        }

        public Task<IEnumerable<Anime>> GetAnimeByFilter(int? id = null, string? nome = null, string? diretor = null)
        {
            throw new NotImplementedException();
        }

        public Task<Anime?> GetAnimeById(int id) =>
            Task.FromResult(Animes.Find(a => a.Id == id));
        public Task<IEnumerable<Anime>> GetAnimes(int pageNumber = 1, int pageSize = 10) =>
         Task.FromResult<IEnumerable<Anime>>(Animes);
        public void UpdateAnime(Anime anime) { }
    }
}
