﻿using BarberTech.Domain.Entities;
using BarberTech.Domain.Repositories;
using MediatR;
using NetTopologySuite.Geometries;

namespace BarberTech.Application.Commands.Establishments.Create
{
    public class CreateEstablishmentCommandHandler : IRequestHandler<CreateEstablishmentCommand, Nothing>
    {
        private readonly IEstablishmentRepository _establishmentRepository;

        public CreateEstablishmentCommandHandler(IEstablishmentRepository establishmentRepository)
        {
            _establishmentRepository = establishmentRepository;
        }

        public async Task<Nothing> Handle(CreateEstablishmentCommand request, CancellationToken cancellationToken)
        {
            var point = new Point(request.Longitude, request.Latitude);

            var establishment = new Establishment(request.Address, point, request.Description, request.BusinessHours, request.ImageSource);

            _establishmentRepository.Add(establishment);
            await _establishmentRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
