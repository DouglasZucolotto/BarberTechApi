using FluentValidation;

namespace BarberTech.Application.Queries.Barbers.AvailableTimes
{
    public class GetAvailableTimesQueryValidator : AbstractValidator<GetAvailableTimesQuery>
    {
        public GetAvailableTimesQueryValidator()
        {
            RuleFor(at => at.Id)
                .NotEmpty();

            RuleFor(at => at.Date)
                .NotEmpty()
                .Matches(@"^\d{2}/\d{2}/\d{4}")
                .WithMessage("The date must be in the format dd/mm/yyyy");
        }
    }
}
