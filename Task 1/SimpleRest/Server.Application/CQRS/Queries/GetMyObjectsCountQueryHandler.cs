using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Server.Domain.Interfaces;

namespace Server.Application.CQRS.Queries
{
    public class GetMyObjectsCountQueryHandler: IRequestHandler<GetMyObjectsCountQuery, int>
    {
        private readonly IMyObjectsRepository _repository;

        public GetMyObjectsCountQueryHandler(IMyObjectsRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(GetMyObjectsCountQuery request, CancellationToken cancellationToken) =>
            await _repository.GetCount((e) => true);
    }
}