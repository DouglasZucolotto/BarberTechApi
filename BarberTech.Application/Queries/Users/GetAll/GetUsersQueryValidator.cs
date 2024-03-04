using FluentValidation;

namespace BarberTech.Application.Queries.Users.GetAll
{
    public class GetUsersQueryValidator : AbstractValidator<GetUsersQuery>
    {
        public GetUsersQueryValidator()
        {
            RuleFor(u => u.Page)
                .NotNull();

            RuleFor(u => u.PageSize)
                .NotNull();
        }
    }
}
