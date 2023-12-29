using BarberTech.Infraestructure.Entities;
using BarberTech.Infraestructure;
using MediatR;

namespace BarberTech.Application.Commands.Feedbacks.Create
{
    public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, Nothing>
    {
        private readonly DataContext _context;

        public CreateFeedbackCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Nothing> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
        {
            var feedback = new Feedback(request.UserId, request.Comment, request.Qnt_stars, request.FeedbackId);
            {
                _context.Feedbacks.Add(feedback);
                await _context.SaveChangesAsync();

                return Nothing.Value;
            };
        }
    }
}
