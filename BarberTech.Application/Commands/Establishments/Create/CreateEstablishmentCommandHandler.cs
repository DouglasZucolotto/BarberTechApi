using BarberTech.Domain;
using BarberTech.Domain.Entities;
using BarberTech.Domain.Repositories;
using MediatR;
using NetTopologySuite.Geometries;

namespace BarberTech.Application.Commands.Establishments.Create
{
    public class CreateEstablishmentCommandHandler : IRequestHandler<CreateEstablishmentCommand, Nothing>
    {
        private readonly IEstablishmentRepository _establishmentRepository;

        public CreateEstablishmentCommandHandler(IEstablishmentRepository establishmentRepository)
        {
            _establishmentRepository = establishmentRepository;
        }

        public async Task<Nothing> Handle(CreateEstablishmentCommand request, CancellationToken cancellationToken)
        {
            var establishment = new Establishment(
                request.Address,
                request.ImageSource,
                TimeSpan.Parse(request.OpenTime),
                TimeSpan.Parse(request.LunchTime),
                TimeSpan.Parse(request.WorkInterval),
                TimeSpan.Parse(request.LunchInterval));

            _establishmentRepository.Add(establishment);
            await _establishmentRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
