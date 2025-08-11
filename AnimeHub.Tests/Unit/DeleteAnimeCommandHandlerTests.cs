using AnimeHub.Application.Animes.Commands;
using AnimeHub.Domain.Entities;
using AnimeHub.Tests.Unit.Fakes;

namespace AnimeHub.Tests.Unit
{
    public class DeleteAnimeCommandHandlerTests
    {
        [Fact]
        public async Task Deve_DeletarAnime_QuandoExistir()
        {
            // Arrange
            var anime = new Anime("Naruto", "Hayato Date", "Ninja de Konoha");
            var fakeRepo = new FakeAnimeRepository();
            fakeRepo.Animes.Add(anime);

            var fakeUow = new FakeUnitOfWork(fakeRepo);
            var handler = new DeleteAnimeCommand.DeleteAnimeCommandHandler(fakeUow);

            var command = new DeleteAnimeCommand { Id = anime.Id };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(anime.Id, result.Id);
            Assert.Empty(fakeRepo.Animes);
        }
    }
}
