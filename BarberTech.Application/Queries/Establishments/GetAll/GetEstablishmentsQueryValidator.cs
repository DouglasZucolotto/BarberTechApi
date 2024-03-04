using FluentValidation;

namespace BarberTech.Application.Queries.Establishments.GetAll
{
    public class GetEstablishmentsQueryValidator : AbstractValidator<GetEstablishmentsQuery>
    {
        public GetEstablishmentsQueryValidator()
        {
            RuleFor(e => e.Page)
                .NotNull();

            RuleFor(e => e.PageSize)
                .NotNull();
        }
    }
}
