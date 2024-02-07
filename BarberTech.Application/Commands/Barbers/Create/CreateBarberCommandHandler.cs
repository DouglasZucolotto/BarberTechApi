using BarberTech.Application.Commands.Users.Register;
using BarberTech.Domain;
using BarberTech.Domain.Entities;
using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Commands.Barbers.Create
{
    public class CreateBarberCommandHandler : IRequestHandler<CreateBarberCommand, Nothing>
    {
        private readonly IMediator _mediator;
        private readonly IBarberRepository _barberRepository;
        private readonly IEstablishmentRepository _establishmentRepository;
        private readonly INotificationContext _notification;

        public CreateBarberCommandHandler(
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

        public async Task<Nothing> Handle(CreateBarberCommand request, CancellationToken cancellationToken)
        {
            var establishment = await _establishmentRepository.GetByIdAsync(request.EstablishmentId);

            if (establishment == null)
            {
                _notification.AddNotFound("Establishment does not exists");
                return default;
            }

            var command = new RegisterUserCommand(request.Email, request.Password, request.Name);
            var user = await _mediator.Send(command);

            var barber = new Barber(user, establishment, request.Contact, request.About, request.ImageSource);

            _barberRepository.Add(barber);
            await _barberRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
