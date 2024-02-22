using BarberTech.Application.Commands.Users.Update;
using BarberTech.Domain;
using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Commands.Barbers.Update
{
    public class UpdateBarberCommandHandler : IRequestHandler<UpdateBarberCommand, Nothing>
    {
        private readonly IMediator _mediator;
        private readonly IBarberRepository _barberRepository;
        private readonly IEstablishmentRepository _establishmentRepository;
        private readonly INotificationContext _notification;

        public UpdateBarberCommandHandler(
            IMediator mediator,
            IBarberRepository barberRepository, 
            IEstablishmentRepository establishmentRepository, 
            INotificationContext notification)
        {
            _mediator = mediator;
            _barberRepository = barberRepository;
            _establishmentRepository = establishmentRepository;
            _notification = notification;
        }

        public async Task<Nothing> Handle(UpdateBarberCommand request, CancellationToken cancellationToken)
        {
            var barber = await _barberRepository.GetByIdAsync(request.Id);

            if (barber == null)
            {
                _notification.AddNotFound("Barber does not exists");
                return default;
            }

            if (request.EstablishmentId != null)
            {
                var establishment = await _establishmentRepository.GetByIdAsync(request.EstablishmentId.Value);

                if (establishment == null)
                {
                    _notification.AddNotFound("Establishment does not exists");
                    return default;
                }

                barber.Establishment = establishment;
                barber.EstablishmentId = establishment.Id;
            }

            if (request.Email != null || request.Password != null || request.Name != null || request.ImageSource != null)
            {
                var command = new UpdateUserCommand(request.Email, request.Password, request.Name, request.ImageSource);
                await _mediator.Send(command.WithId(barber.UserId));
            }

            barber.About = request.About ?? barber.About;
            barber.Contact = request.Contact ?? barber.Contact;

            _barberRepository.Update(barber);
            await _barberRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
