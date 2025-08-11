using AnimeHub.Application.Animes.Commands;
using AnimeHub.Domain.Entities;
using AnimeHub.Tests.Unit.Fakes;
namespace AnimeHub.Tests.Unit
{
    public class UpdateAnimeCommandHandlerTests
    {
        [Fact]
        public async Task Deve_AtualizarAnime_QuandoExistir()
        {
            // Arrange
            var animeExistente = new Anime("Naruto", "Hayato Date", "Ninja de Konoha");
            animeExistente.Update("Naruto", "Diretor Original", "Resumo Original");

            var fakeRepo = new FakeAnimeRepository();
            fakeRepo.Animes.Add(animeExistente);

            var fakeUow = new FakeUnitOfWork(fakeRepo);
            var handler = new UpdateAnimeCommand.UpdateAnimeCommandHandler(fakeUow);

            var command = new UpdateAnimeCommand
            {
                Id = animeExistente.Id,
                Nome = "Naruto Shippuden",
                Diretor = "Hayato Date",
                Resumo = "Nova fase"
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal("Naruto Shippuden", result.Nome);
            Assert.Equal("Nova fase", result.Resumo);
        }
    }
}
