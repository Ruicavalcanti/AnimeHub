using AnimeHub.Domain.Abstractions;
using AnimeHub.Domain.Entities;
using MediatR;

namespace AnimeHub.Application.Animes.Queries
{
    public class GetAnimesQuery : IRequest<IEnumerable<Anime>>
    {
        public int Id { get; set; }
        public string Nome { get; set; } = String.Empty;
        public string Diretor { get; set; } = String.Empty;
        public class GetAnimesQueryHandler : IRequestHandler<GetAnimesQuery, IEnumerable<Anime>>
        {
            private readonly IUnitOfWork _unitOfWork;
            public GetAnimesQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<IEnumerable<Anime>> Handle(GetAnimesQuery request, CancellationToken cancellationToken)
            {
                var animes = await _unitOfWork.AnimeRepository.GetAnimes();
                return animes;
            }

        }
    }
}

