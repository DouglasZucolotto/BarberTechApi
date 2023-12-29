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
                // TODO: notificator
                return default;
            }

            feedback.Comment = request.Comment;
            feedback.QntStars = request.QntStars;

            _context.Feedbacks.Update(feedback);
            await _context.SaveChangesAsync();

            return Nothing.Value;
        }
    }
}
