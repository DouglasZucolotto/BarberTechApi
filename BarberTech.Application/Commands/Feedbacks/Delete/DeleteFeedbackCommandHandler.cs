using BarberTech.Infraestructure;
using MediatR;

namespace BarberTech.Application.Commands.Feedbacks.Delete
{
    public class DeleteFeedbackCommandHandler : IRequestHandler<DeleteFeedbackCommand, Nothing>
    {
        private readonly DataContext _context;

        public DeleteFeedbackCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Nothing> Handle(DeleteFeedbackCommand request, CancellationToken cancellationToken)
        {
            var feedback = _context.Feedbacks.FirstOrDefault(f => f.Id == request.Id);

            if (feedback is null)
            {
                return Nothing.Value;
            }

            _context.Feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();

            return Nothing.Value;
        }
    }
}
