using BarberTech.Domain.Repositories;
using BarberTech.Infraestructure;
using MediatR;

namespace BarberTech.Application.Commands.Establishments.Delete
{
    public class DeleteEstablishmentCommandHandler : IRequestHandler<DeleteEstablishmentCommand, Nothing>
    {
        private readonly IEstablishmentRepository _establishmentRepository;

        public DeleteEstablishmentCommandHandler(IEstablishmentRepository establishmentRepository)
        {
            _establishmentRepository = establishmentRepository;
        }

        public async Task<Nothing> Handle(DeleteEstablishmentCommand request, CancellationToken cancellationToken)
        {
            var establishment = await _establishmentRepository.GetByIdAsync(request.Id);

            if (establishment is null)
            {
                return Nothing.Value;
            }

            _establishmentRepository.Remove(establishment);
            await _establishmentRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
