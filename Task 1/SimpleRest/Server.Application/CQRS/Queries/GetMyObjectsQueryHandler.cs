using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Server.Domain.Interfaces;
using Server.Domain.Models;

namespace Server.Application.CQRS.Queries
{
    public class GetMyObjectsQueryHandler : IRequestHandler<GetMyObjectsQuery, IEnumerable<MyObjectModel>>
    {
        private readonly IMyObjectsRepository _repository;

        public GetMyObjectsQueryHandler(IMyObjectsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MyObjectModel>> Handle(GetMyObjectsQuery request,
            CancellationToken cancellationToken)
        {
            var myObjects = await _repository.Query(request.Take, request.Offset);
            return myObjects.Select(o => new MyObjectModel
            {
                Id = o.Id,
                Code = o.Code,
                Value = o.Value
            });
        }
    }
}