using BarberTech.Domain.Repositories;
using MediatR;
using BarberTech.Domain.Entities;
using BarberTech.Domain;

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
            var imageSource = $"https://ucarecdn.com/5d8878dd-0109-4905-ace3-fa1fda031999/{request.ImageSource}";

            var haircut = new Haircut(request.Name, request.About, imageSource, request.Price);

            _haircutRepository.Add(haircut);
            await _haircutRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
