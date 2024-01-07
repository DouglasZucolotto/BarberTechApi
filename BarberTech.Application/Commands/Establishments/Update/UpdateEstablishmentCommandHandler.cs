using BarberTech.Domain.Repositories;
using BarberTech.Infraestructure;
using MediatR;

namespace BarberTech.Application.Commands.Establishments.Update
{
    public class UpdateEstablishmentCommandHandler : IRequestHandler<UpdateEstablishmentCommand, Nothing>
    {
        private readonly IEstablishmentRepository _establishmentRepository;

        public UpdateEstablishmentCommandHandler(IEstablishmentRepository establishmentRepository)
        {
            _establishmentRepository = establishmentRepository;
        }
        public async Task<Nothing> Handle(UpdateEstablishmentCommand request, CancellationToken cancellationToken)
        {
            var establishment = await _establishmentRepository.GetByIdAsync(request.Id);

            if (establishment is null)
            {
                return Nothing.Value;
            }

            establishment.Address = request.Address;
            establishment.Coordinates = request.Coordinates;
            establishment.ImageSource = request.ImageSource;
            establishment.Description = request.Description;
            establishment.BusinessHours = request.BusinessHours;

            _establishmentRepository.Update(establishment);
            await _establishmentRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
