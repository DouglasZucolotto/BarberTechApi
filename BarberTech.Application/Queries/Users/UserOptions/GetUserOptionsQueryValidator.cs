using FluentValidation;

namespace BarberTech.Application.Queries.Users.UserOptions
{
    public class GetUserOptionsQueryValidator : AbstractValidator<GetUserOptionsQuery>
    {
        public GetUserOptionsQueryValidator()
        {
        }
    }
}
