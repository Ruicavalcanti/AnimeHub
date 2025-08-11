using AnimeHub.Domain.Abstractions;
using AnimeHub.Domain.Entities;
using MediatR;

namespace AnimeHub.Application.Animes.Queries
{
    public class GetAnimeFilterQuery : IRequest<Anime>
    {
        public int Id { get; set; }
        public class GetAnimeFilterQueryQueryHandler : IRequestHandler<GetAnimeFilterQuery, Anime>
        {
            private readonly IUnitOfWork _unitOfWork;
            public GetAnimeFilterQueryQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<Anime> Handle(GetAnimeFilterQuery request, CancellationToken cancellationToken)
            {
                var anime = await _unitOfWork.AnimeRepository.GetAnimeById(request.Id);
                return anime;
            }

        }
    }
}


