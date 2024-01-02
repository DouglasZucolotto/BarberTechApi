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
            // TODO: Pegar id usuário logado // remover userTest

            var userTest = new User("email", "password", "name", "image");

            var feedback = new Feedback(userTest, request.Comment, request.QntStars);

            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            return Nothing.Value;
        }
    }
}
