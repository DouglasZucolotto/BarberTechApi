using FluentValidation;

namespace BarberTech.Application.Queries.Feedbacks.GetAll
{
    public class GetFeedbacksQueryValidator : AbstractValidator<GetFeedbacksQuery>
    {
        public GetFeedbacksQueryValidator()
        {
            RuleFor(f => f.Page)
                .NotNull();

            RuleFor(f => f.PageSize)
                .NotNull();
        }
    }
}
