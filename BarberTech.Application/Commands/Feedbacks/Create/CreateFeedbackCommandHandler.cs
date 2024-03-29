﻿using BarberTech.Domain;
using BarberTech.Domain.Authentication;
using BarberTech.Domain.Entities;
using BarberTech.Domain.Entities.Enums;
using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Commands.Feedbacks.Create
{
    public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, CreateFeedbackCommandResponse?>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IEventScheduleRepository _eventScheduleRepository;
        private readonly IHttpContext _httpContext;
        private readonly INotificationContext _notification;

        public CreateFeedbackCommandHandler(
            IFeedbackRepository feedbackRepository, 
            IEventScheduleRepository eventScheduleRepository,
            IHttpContext httpContext,
            INotificationContext notification)
        {
            _feedbackRepository = feedbackRepository;
            _eventScheduleRepository = eventScheduleRepository;
            _httpContext = httpContext;
            _notification = notification;
        }

        public async Task<CreateFeedbackCommandResponse?> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
        {
            var user = await _httpContext.GetUserAsync();

            if (user == null)
            {
                _notification.AddNotFound("User does not exists");
                return default;
            }

            var eventSchedule = await _eventScheduleRepository.GetByIdWithEstablishment(request.EventScheduleId);

            if (eventSchedule == null)
            {
                _notification.AddNotFound("Event Schedule does not exists");
                return default;
            }

            if (eventSchedule.EventStatus != EventStatus.Completed)
            {
                _notification.AddNotFound("Event Schedule should be completed");
                return default;
            }

            if (eventSchedule.UserId != user.Id)
            {
                _notification.AddNotFound("Only the user who started the event can rate");
                return default;
            }

            if (eventSchedule.FeedbackId != null)
            {
                _notification.AddBadRequest("Event already have a feedback");
                return default;
            }

            var feedback = new Feedback(
                user, 
                eventSchedule.Barber,
                eventSchedule.Haircut,
                eventSchedule.Barber.Establishment,
                request.RatingBarber,
                request.RatingHaircut,
                request.RatingEstablishment,
                request.Comment);

            eventSchedule.Feedback = feedback;
            eventSchedule.FeedbackId = feedback.Id;

            _feedbackRepository.Add(feedback);
            await _feedbackRepository.UnitOfWork.CommitAsync();

            return new CreateFeedbackCommandResponse
            {
                RatingAvarege = feedback.GetRatingAverage()
            };
        }
    }
}
