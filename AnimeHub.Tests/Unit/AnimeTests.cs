using AnimeHub.Domain.Entities;
using AnimeHub.Domain.Validation;
public class AnimeTests
{
    [Fact]
    public void CriarAnime_Valido_NaoDeveLancar()
    {
        var anime = new Anime("Naruto", "Hayato Date", "Resumo válido");
        Assert.NotNull(anime);
        Assert.Equal("Naruto", anime.Nome);
    }

    [Theory]
    [InlineData(null, "Diretor", "Resumo")]
    [InlineData("No", "Diretor", "Resumo")]
    [InlineData("Nome", null, "Resumo")]
    [InlineData("Nome", "Di", "Resumo")]
    [InlineData("Nome", "Diretor", null)]
    [InlineData("Nome", "Diretor", "Re")]
    public void CriarAnime_Invalido_DeveLancar(string nome, string diretor, string resumo)
    {
        Assert.Throws<DomainValidation>(() => new Anime(nome, diretor, resumo));
    }

    [Fact]
    public void AtualizarAnime_Valido_DeveAlterarCampos()
    {
        var anime = new Anime("Naruto", "Hayato Date", "Resumo");
        anime.Update("Bleach", "Noriyuki Abe", "Novo Resumo");
        Assert.Equal("Bleach", anime.Nome);
    }
}
