using AnimeHub.Domain.Abstractions;
using AnimeHub.Domain.Entities;
using MediatR;
namespace AnimeHub.Application.Animes.Commands
{
    public sealed class UpdateAnimeCommand : AnimeCommandBase
    {
        public int Id { get; set; }

        public class UpdateAnimeCommandHandler : IRequestHandler<UpdateAnimeCommand, Anime>
        {
            private readonly IUnitOfWork _unitOfWork;
            public UpdateAnimeCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Anime> Handle(UpdateAnimeCommand request, CancellationToken cancellationToken)
            {
                var anime = await _unitOfWork.AnimeRepository.GetAnimeById(request.Id);
                if (anime is null)
                    throw new InvalidOperationException("Anime não encontrado");
                anime.Update(request.Nome, request.Diretor, request.Resumo);
                _unitOfWork.AnimeRepository.UpdateAnime(anime);
                await _unitOfWork.CommitAsync();
                return anime;
            }
        }
    }
}
