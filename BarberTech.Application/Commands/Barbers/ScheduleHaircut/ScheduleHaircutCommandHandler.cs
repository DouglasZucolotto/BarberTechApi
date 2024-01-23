using BarberTech.Domain;
using BarberTech.Domain.Authentication;
using BarberTech.Domain.Entities;
using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;
using System.Globalization;

namespace BarberTech.Application.Commands.Barbers.ScheduleHaircut
{
    public class ScheduleHaircutCommandHandler : IRequestHandler<ScheduleHaircutCommand, Nothing>
    {
        private readonly IEstablishmentRepository _establishmentRepository;
        private readonly IEventScheduleRepository _eventScheduleRepository;
        private readonly INotificationContext _notification;
        private readonly IHttpContext _httpContext;

        public ScheduleHaircutCommandHandler(
            IEstablishmentRepository establishmentRepository,
            IEventScheduleRepository eventScheduleRepository,
            INotificationContext notification,
            IHttpContext httpContext)
        {
            _establishmentRepository = establishmentRepository;
            _eventScheduleRepository = eventScheduleRepository;
            _notification = notification;
            _httpContext = httpContext;
        }

        public async Task<Nothing> Handle(ScheduleHaircutCommand request, CancellationToken cancellationToken)
        {
            var establishment = await _establishmentRepository.GetByIdWithBarbersAsync(request.EstablishmentId);

            if (establishment is null)
            {
                _notification.AddNotFound("Establishment does not exists");
                return default;
            }

            var barber = establishment.Barbers.FirstOrDefault(b => b.Id == request.BarberId);

            if (barber is null)
            {
                _notification.AddNotFound("Barber does not exists");
                return default;
            }

            var dateTime = ConverterToDateTime(request.DateTime);

            if (dateTime is null)
            {
                _notification.AddBadRequest("Could not convert dateTime values");
                return default;
            }

            var userId = _httpContext.GetUserId();
            //TODO: pegar o usuario inteiro e passar request.Name ?? user.Name

            var eventSchedule = new EventSchedule(userId, barber.Id, request.Name, establishment.Id, dateTime.Value);

            _eventScheduleRepository.Add(eventSchedule);
            await _eventScheduleRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }

        private DateTime? ConverterToDateTime(string dateTime)
        {
            var dateTimeFormat = "dd/MM/yyyy HH:mm";

            var formatSuccess = DateTime.TryParseExact(
                dateTime, 
                dateTimeFormat, 
                CultureInfo.InvariantCulture, 
                DateTimeStyles.None, 
                out var dateTimeFormatted);

            return formatSuccess ? dateTimeFormatted.ToUniversalTime() : null;
        }
    }
}
