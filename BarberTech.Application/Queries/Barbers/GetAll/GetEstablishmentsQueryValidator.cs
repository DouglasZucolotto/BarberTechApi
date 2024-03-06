using FluentValidation;

namespace BarberTech.Application.Queries.Barbers.GetAll
{
    public class GetBarbersQueryValidator : AbstractValidator<GetBarbersQuery>
    {
        public GetBarbersQueryValidator()
        {
            RuleFor(b => b.Page)
                .NotNull();

            RuleFor(b => b.PageSize)
                .NotNull();
        }
    }
}
