using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Server.Domain.Entities.Impl;
using Server.Domain.Interfaces;

namespace Server.Application.CQRS.Commands
{
    public class AddMyObjectsQueryHandler : IRequestHandler<AddMyObjectsQuery, Unit>
    {
        private readonly IMyObjectsRepository _repository;

        public AddMyObjectsQueryHandler(IMyObjectsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AddMyObjectsQuery request, CancellationToken cancellationToken)
        {
            await _repository.ClearTable();

            var result = new List<MyObject>();
            try
            {
                if (!request.Data.Any()) throw new Exception("Invalid request body");

                result.AddRange(request.Data
                    .Select(i => new MyObject
                    {
                        Code = int.Parse(i.Keys.SingleOrDefault() ?? ""),
                        Value = i.Values.SingleOrDefault()
                    })
                    .ToList());
            }
            catch (Exception e)
            {
                throw new ValidationException(e.Message);
            }

            result.Sort((first, second) => first.Code - second.Code);

            await _repository.SaveAll(result);
            return Unit.Value;
        }
    }
}