using AnimeHub.Domain.Abstractions;
using AnimeHub.Domain.Entities;
using MediatR;
namespace AnimeHub.Application.Animes.Commands
{
    public sealed class DeleteAnimeCommand : IRequest<Anime>
    {
        public int Id { get; set; }

        public class DeleteAnimeCommandHandler : IRequestHandler<DeleteAnimeCommand, Anime>
        {
            private readonly IUnitOfWork _unitOfWork;
            public DeleteAnimeCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<Anime> Handle(DeleteAnimeCommand request, CancellationToken cancellationToken)
            {
                var anime = await _unitOfWork.AnimeRepository.DeleteAnime(request.Id);
                if (anime == null)
                    throw new InvalidOperationException("Anime não encontrado");
                await _unitOfWork.CommitAsync();
                return anime;
            }
        }
    }
}

