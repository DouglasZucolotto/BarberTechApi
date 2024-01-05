using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Commands.Haircuts.Delete
{
    public class DeleteHaircutCommandHandler : IRequestHandler<DeleteHaircutCommand, Nothing>
    {
        private readonly IHaircutRepository _haircutRepository;

        public DeleteHaircutCommandHandler(IHaircutRepository haircutRepository)
        {
            _haircutRepository = haircutRepository;
        }

        public async Task<Nothing> Handle(DeleteHaircutCommand request, CancellationToken cancellationToken)
        {
            var haircut = await _haircutRepository.GetByIdAsync(request.Id);

            if (haircut is null)
            {
                // TODO: notificator
                return default;
            }

            _haircutRepository.Remove(haircut);
            await _haircutRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
