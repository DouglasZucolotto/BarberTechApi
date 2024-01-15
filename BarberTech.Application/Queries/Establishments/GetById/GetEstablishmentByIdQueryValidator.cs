using FluentValidation;

namespace BarberTech.Application.Queries.Establishments.GetById
{
    public class GetEstablishmentByIdQueryValidator : AbstractValidator<GetEstablishmentByIdQuery>
    {
        public GetEstablishmentByIdQueryValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty();
        }
    }
}
