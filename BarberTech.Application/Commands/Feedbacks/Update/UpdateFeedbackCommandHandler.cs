using BarberTech.Infraestructure;
using MediatR;

namespace BarberTech.Application.Commands.Feedbacks.Update
{
    public class UpdateFeedbackCommandHandler : IRequestHandler<UpdateFeedbackCommand, Nothing>
    {
        private readonly DataContext _context;

        public UpdateFeedbackCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Nothing> Handle(UpdateFeedbackCommand request, CancellationToken cancellationToken)
        {
            var feedback = _context.Feedbacks.FirstOrDefault(f => f.Id == request.Id);

            if (feedback is null)
            {
                return Nothing.Value;
            }

            feedback.UserId = request.UserId;
            feedback.Comment = request.Comment;
            feedback.Qnt_stars = request.Qnt_stars;
            feedback.FeedbackId = request.FeedbackId;

            _context.Feedbacks.Update(feedback);
            await _context.SaveChangesAsync();

            return Nothing.Value;
        }
    }
}
