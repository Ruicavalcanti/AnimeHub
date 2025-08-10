namespace AnimeHub.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IAnimeRepository AnimeRepository { get; }
        Task CommitAsync();
    }
}
