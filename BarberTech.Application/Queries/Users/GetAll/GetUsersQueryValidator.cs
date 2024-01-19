using FluentValidation;

namespace BarberTech.Application.Queries.Users.GetAll
{
    public class GetUsersQueryValidator : AbstractValidator<GetUsersQuery>
    {
        public GetUsersQueryValidator()
        {
        }
    }
}
