using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using BarberTech.Infraestructure;
using MediatR;
using NetTopologySuite.Geometries;

namespace BarberTech.Application.Commands.Establishments.Update
{
    public class UpdateEstablishmentCommandHandler : IRequestHandler<UpdateEstablishmentCommand, Nothing>
    {
        private readonly IEstablishmentRepository _establishmentRepository;
        private readonly INotificationContext _notification;

        public UpdateEstablishmentCommandHandler(IEstablishmentRepository establishmentRepository, INotificationContext notification)
        {
            _establishmentRepository = establishmentRepository;
            _notification = notification;
        }

        public async Task<Nothing> Handle(UpdateEstablishmentCommand request, CancellationToken cancellationToken)
        {
            var establishment = await _establishmentRepository.GetByIdAsync(request.Id);

            if (establishment is null)
            {
                _notification.AddNotFound("Establishment does not exists");
                return default;
            }

            var coordinates = new Point(request.Longitude, request.Latitude);

            establishment.Address = request.Address;
            establishment.Coordinates = coordinates;
            establishment.ImageSource = request.ImageSource;
            establishment.Description = request.Description;
            establishment.BusinessHours = request.BusinessHours;

            _establishmentRepository.Update(establishment);
            await _establishmentRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
