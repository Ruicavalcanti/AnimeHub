using AnimeHub.Domain.Entities;
namespace AnimeHub.Domain.Abstractions
{
    public interface IAnimeRepository
    {
        Task<IEnumerable<Anime>> GetAnimes(int pageNumber = 1, int pageSize = 10);
        Task<IEnumerable<Anime>> GetAnimeByFilter(int? id = null, string? nome = null, string? diretor = null);
        Task<Anime> GetAnimeById(int id);
        Task<Anime> AddAnime(Anime anime);
        void UpdateAnime(Anime anime);
        Task<Anime> DeleteAnime(int animeId);
    }
}