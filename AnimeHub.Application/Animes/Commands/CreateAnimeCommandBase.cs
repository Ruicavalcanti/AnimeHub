using AnimeHub.Domain.Abstractions;
using AnimeHub.Domain.Entities;
using MediatR;

namespace AnimeHub.Application.Animes.Commands
{
    public class CreateAnimeCommand : AnimeCommandBase
    {
        public class CreateAnimeCommandHandler : IRequestHandler<CreateAnimeCommand, Anime>
        {
            private readonly IUnitOfWork _unitOfWork;

            public CreateAnimeCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<Anime> Handle(CreateAnimeCommand request, CancellationToken cancellationToken)
            {
                var anime = new Anime(request.Nome, request.Diretor, request.Resumo);
                await _unitOfWork.AnimeRepository.AddAnime(anime);
                await _unitOfWork.CommitAsync();
                return anime;
            }
        }

    }
}
