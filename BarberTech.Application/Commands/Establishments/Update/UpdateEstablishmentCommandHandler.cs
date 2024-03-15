using BarberTech.Domain;
using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
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

            if (request.OpenTime != null)
            {
                establishment.OpenTime = TimeSpan.Parse(request.OpenTime);
            }

            if (request.LunchTime != null)
            {
                establishment.LunchTime = TimeSpan.Parse(request.LunchTime);
            }

            if (request.WorkInterval != null)
            {
                establishment.WorkInterval = TimeSpan.Parse(request.WorkInterval);
            }

            if (request.LunchInterval != null)
            {
                establishment.LunchInterval = TimeSpan.Parse(request.LunchInterval);
            }

            if (request.ImageSource != null)
            {
                var imageSource = $"https://ucarecdn.com/5d8878dd-0109-4905-ace3-fa1fda031999/{request.ImageSource}";
                establishment.ImageSource = imageSource;
            }

            establishment.Address = request.Address ?? establishment.Address;

            _establishmentRepository.Update(establishment);
            await _establishmentRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
