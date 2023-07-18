using System.Collections.Generic;
using MediatR;
using Server.Domain.Models;

namespace Server.Application.CQRS.Queries
{
    public class GetMyObjectsQuery : IRequest<IEnumerable<MyObjectModel>>
    {
        public int Take { get; set; }
        public int Offset { get; set; }
    }
}