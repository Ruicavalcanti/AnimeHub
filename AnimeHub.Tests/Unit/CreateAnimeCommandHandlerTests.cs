using AnimeHub.Application.Animes.Commands;
using AnimeHub.Tests.Unit.Fakes;
namespace AnimeHub.Tests.Application.Animes.Commands
{
    public class CreateAnimeCommandHandlerTests
    {
        [Fact]
        public async Task Handle_DeveCriarAnime_QuandoDadosValidos()
        {
            // Arrange
            var fakeRepo = new FakeAnimeRepository();
            var fakeUow = new FakeUnitOfWork(fakeRepo);

            var handler = new CreateAnimeCommand.CreateAnimeCommandHandler(fakeUow);
            var command = new CreateAnimeCommand
            {
                Nome = "Naruto",
                Diretor = "Hayato Date",
                Resumo = "Ninja de Konoha"
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Naruto", result.Nome);
            Assert.Single(fakeRepo.Animes);
        }
    }
}
