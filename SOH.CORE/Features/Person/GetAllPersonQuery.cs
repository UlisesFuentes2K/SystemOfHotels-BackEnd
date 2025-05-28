using MediatR;
using SOH.CORE.Interfaces;
using SOH.MAIN.Models.Customer;

namespace SOH.CORE.Features.Person
{
    public class GetAllPersonQuery   : IRequest<List<SR_Person>>{ }

    internal class GetAllPersonQueryHandler : IRequestHandler<GetAllPersonQuery, List<SR_Person>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPersonQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<SR_Person>> Handle(GetAllPersonQuery request, CancellationToken cancellationToken)
        {
            // Traer los datos de la persona.
            return await _unitOfWork.UPerson.GetAllValues(x => x.City, x=> x.City.Country);
        }
    }
}
