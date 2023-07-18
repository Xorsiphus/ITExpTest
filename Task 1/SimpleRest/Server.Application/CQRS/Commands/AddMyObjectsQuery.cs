using System.Collections.Generic;
using MediatR;

namespace Server.Application.CQRS.Commands
{
    public class AddMyObjectsQuery : IRequest<Unit>
    {
        public IEnumerable<Dictionary<string, string>> Data { get; set; }
    }
}