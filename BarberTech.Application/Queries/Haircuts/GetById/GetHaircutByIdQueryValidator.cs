using FluentValidation;

namespace BarberTech.Application.Queries.Haircuts.GetById
{
    public class GetHaircutByIdQueryValidator : AbstractValidator<GetHaircutByIdQuery>
    {
        public GetHaircutByIdQueryValidator()
        {
            RuleFor(f => f.Id)
                .NotEmpty();
        }
    }
}

