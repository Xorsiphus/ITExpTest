using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Api.Requests;
using Server.Application.CQRS.Commands;
using Server.Application.CQRS.Queries;
using Server.Domain.Models;

namespace Server.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MyObjectController : Controller
    {
        private readonly IMediator _mediator;

        public MyObjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task AddObjects([FromBody] IEnumerable<Dictionary<string, string>> data)
        {
            await _mediator.Send(new AddMyObjectsQuery { Data = data });
        }

        [HttpGet]
        public async Task<IEnumerable<MyObjectModel>> GetObjects([FromQuery] GetMyObjectsRequestModel options)
            => await _mediator.Send(new GetMyObjectsQuery { Take = options.Take, Offset = options.Offset });

        [HttpGet]
        [Route("[action]")]
        public async Task<int> GetMyObjectsCount()
            => await _mediator.Send(new GetMyObjectsCountQuery());
    }
}