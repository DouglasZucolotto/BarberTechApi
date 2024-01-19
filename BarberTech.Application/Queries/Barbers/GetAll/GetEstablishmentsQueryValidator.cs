using FluentValidation;

namespace BarberTech.Application.Queries.Barbers.GetAll
{
    public class GetBarbersQueryValidator : AbstractValidator<GetBarbersQuery>
    {
        public GetBarbersQueryValidator()
        {
        }
    }
}
