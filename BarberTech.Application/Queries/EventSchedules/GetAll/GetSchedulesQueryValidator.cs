using FluentValidation;

namespace BarberTech.Application.Queries.EventSchedules.GetAll
{
    public class GetSchedulesQueryValidator : AbstractValidator<GetSchedulesQuery>
    {
        public GetSchedulesQueryValidator()
        {
            RuleFor(e => e.Page)
                .NotNull();

            RuleFor(e => e.PageSize)
                .NotNull();
        }
    }
}
