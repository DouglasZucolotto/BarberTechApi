using BarberTech.Domain.Repositories;
using MediatR;
using BarberTech.Domain.Entities;

namespace BarberTech.Application.Commands.Haircuts.Create
{
    public class CreateHaircutCommandHandler : IRequestHandler<CreateHaircutCommand, Nothing>
    {
        private readonly IHaircutRepository _haircutRepository;

        public CreateHaircutCommandHandler(IHaircutRepository haircutRepository)
        {
            _haircutRepository = haircutRepository;
        }

        public async Task<Nothing> Handle(CreateHaircutCommand request, CancellationToken cancellationToken)
        {
            var haircut = new Haircut(request.Name, request.Description, request.ImageSource, request.Price);

            _haircutRepository.Add(haircut);
            await _haircutRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
