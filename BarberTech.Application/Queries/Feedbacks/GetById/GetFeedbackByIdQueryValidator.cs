using FluentValidation;

namespace BarberTech.Application.Queries.Feedbacks.GetById
{
    public class GetHaircutByIdQueryValidator : AbstractValidator<GetFeedbackByIdQuery>
    {
        public GetHaircutByIdQueryValidator()
        {
            RuleFor(f => f.Id)
                .NotEmpty();
        } 
    }
}

