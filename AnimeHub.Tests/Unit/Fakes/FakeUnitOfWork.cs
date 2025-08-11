using AnimeHub.Domain.Abstractions;
namespace AnimeHub.Tests.Unit.Fakes
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        public IAnimeRepository AnimeRepository { get; }
        public FakeUnitOfWork(IAnimeRepository repo) => AnimeRepository = repo;
        public Task CommitAsync() => Task.CompletedTask;
    }

}
