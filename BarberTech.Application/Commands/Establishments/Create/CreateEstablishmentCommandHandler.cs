using BarberTech.Domain;
using BarberTech.Domain.Entities;
using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;
using NetTopologySuite.Geometries;
using System.Globalization;

namespace BarberTech.Application.Commands.Establishments.Create
{
    public class CreateEstablishmentCommandHandler : IRequestHandler<CreateEstablishmentCommand, Nothing>
    {
        private readonly IEstablishmentRepository _establishmentRepository;
        private readonly INotificationContext _notification;

        public CreateEstablishmentCommandHandler(IEstablishmentRepository establishmentRepository, INotificationContext notification)
        {
            _establishmentRepository = establishmentRepository;
            _notification = notification;
        }

        public async Task<Nothing> Handle(CreateEstablishmentCommand request, CancellationToken cancellationToken)
        {
            var coordinates = new Point(request.Longitude, request.Latitude);

            var establishment = new Establishment(
                request.Address, 
                coordinates, 
                request.ImageSource,
                TimeSpan.Parse(request.OpenTime),
                TimeSpan.Parse(request.LunchTime),
                TimeSpan.Parse(request.WorkInterval),
                TimeSpan.Parse(request.LunchInterval),
                request.Description);

            _establishmentRepository.Add(establishment);
            await _establishmentRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
