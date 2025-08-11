using AnimeHub.Application.Animes.Queries;
using AnimeHub.Domain.Entities;
using AnimeHub.Tests.Unit.Fakes;
namespace AnimeHub.Tests.Unit
{
    public class GetAnimesQueryHandlerTests
    {
        [Fact]
        public async Task Deve_RetornarListaDeAnimes()
        {
            // Arrange
            var fakeRepo = new FakeAnimeRepository();
            fakeRepo.Animes.Add(new Anime("Naruto", "Hayato Date", "Ninja de Konoha"));
            fakeRepo.Animes.Add(new Anime("Bleach", "Noriyuki Abe", "Shinigami"));

            var fakeUow = new FakeUnitOfWork(fakeRepo);
            var handler = new GetAnimesQuery.GetAnimesQueryHandler(fakeUow);

            var query = new GetAnimesQuery { Nome = "", Diretor = "" };

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(2, ((List<Anime>)result).Count);
        }
    }
}
