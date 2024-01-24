using BarberTech.Application.Queries.Barbers.GetAll;
using FluentValidation;

namespace BarberTech.Application.Queries.Barbers.AvailableTimes
{
    public class GetAvailableTimesQueryValidator : AbstractValidator<GetAvailableTimesQuery>
    {
        public GetAvailableTimesQueryValidator()
        {
        }
    }
}
