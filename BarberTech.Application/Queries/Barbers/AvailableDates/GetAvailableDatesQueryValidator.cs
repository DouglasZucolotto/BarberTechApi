using FluentValidation;

namespace BarberTech.Application.Queries.Barbers.AvailableDates
{
    public class GetAvailableDatesQueryValidator : AbstractValidator<GetAvailableDatesQuery>
    {
        public GetAvailableDatesQueryValidator()
        {
            RuleFor(ad => ad.Id)
                .NotEmpty();
        }
    }
}
