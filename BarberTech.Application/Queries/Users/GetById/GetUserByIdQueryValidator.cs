using FluentValidation;

namespace BarberTech.Application.Queries.Users.GetById
{
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(u => u.Id)
                .NotEmpty();
        }
    }
}
