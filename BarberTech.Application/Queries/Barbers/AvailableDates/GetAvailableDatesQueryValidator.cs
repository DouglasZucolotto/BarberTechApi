using FluentValidation;

namespace BarberTech.Application.Queries.Barbers.AvailableDates
{
    public class GetAvailableDatesQueryValidator : AbstractValidator<GetAvailableDatesQuery>
    {
        public GetAvailableDatesQueryValidator()
        {
            RuleFor(at => at.Id)
                .NotEmpty();
        }
    }
}
