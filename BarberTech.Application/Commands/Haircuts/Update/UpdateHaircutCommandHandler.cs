using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Commands.Haircuts.Update
{
    public class UpdateHaircutCommandHandler : IRequestHandler<UpdateHaircutCommand, Nothing>
    {
        private readonly IHaircutRepository _haircutRepository;

        public UpdateHaircutCommandHandler(IHaircutRepository haircutRepository)
        {
            _haircutRepository = haircutRepository;
        }

        public async Task<Nothing> Handle(UpdateHaircutCommand request, CancellationToken cancellationToken)
        {
            var haircut = await _haircutRepository.GetByIdAsync(request.Id);

            if (haircut is null)
            {
                // TODO: notificator
                return default;
            }

            haircut.Name = request.Name;
            haircut.Description = request.Description;
            haircut.Price = request.Price;
            haircut.ImageSource = request.ImageSource;

            _haircutRepository.Update(haircut);
            await _haircutRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
