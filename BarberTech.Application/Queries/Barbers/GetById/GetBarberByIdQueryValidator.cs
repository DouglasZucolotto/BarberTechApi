using FluentValidation;

namespace BarberTech.Application.Queries.Barbers.GetById
{
    public class GetBarberByIdQueryValidator : AbstractValidator<GetBarberByIdQuery>
    {
        public GetBarberByIdQueryValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty();
        }
    }
}
