using FluentValidation;

namespace BarberTech.Application.Queries.Barbers.Calendar
{
    public class GetCalendarQueryValidator : AbstractValidator<GetCalendarQuery>
    {
        public GetCalendarQueryValidator()
        {
        }
    }
}
