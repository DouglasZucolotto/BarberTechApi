﻿using FluentValidation;

namespace BarberTech.Application.Commands.Feedbacks.Create
{
    public class CreateFeedbackCommandValidator : AbstractValidator<CreateFeedbackCommand>
    {
        public CreateFeedbackCommandValidator()
        {
            RuleFor(f => f.RatingBarber)
                .ExclusiveBetween(0, 6)
                .NotNull();

            RuleFor(f => f.RatingEstablishment)
                .ExclusiveBetween(0, 6)
                .NotNull();

            RuleFor(f => f.RatingHaircut)
                .ExclusiveBetween(0, 6)
                .NotNull();

            RuleFor(f => f.EventScheduleId)
                .NotEmpty();
        }
    }
}
