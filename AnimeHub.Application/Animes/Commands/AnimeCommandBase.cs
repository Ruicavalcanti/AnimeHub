using AnimeHub.Domain.Entities;
using MediatR;

namespace AnimeHub.Application.Animes.Commands
{
    public abstract class AnimeCommandBase : IRequest<Anime>
    {
        public string Nome { get; set; } = string.Empty;
        public string Diretor { get; set; } = string.Empty;
        public string Resumo { get; set; } = string.Empty;
    }
}
