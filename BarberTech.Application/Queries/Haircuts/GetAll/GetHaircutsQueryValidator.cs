using FluentValidation;

namespace BarberTech.Application.Queries.Haircuts.GetAll
{
    public class GetHaircutsQueryValidator : AbstractValidator<GetHaircutsQuery>
    {
        public GetHaircutsQueryValidator()
        {
        }
    }
}