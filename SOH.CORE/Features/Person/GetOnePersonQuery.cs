using MediatR;
using SOH.CORE.Interfaces;
using SOH.MAIN.Models.Customer;

namespace SOH.CORE.Features.Person
{
    public class GetOnePersonQuery : IRequest<SR_Person>
    {
        public int idPerson { get; set; }
    }

    internal class GetOnePersonQueryHandler : IRequestHandler<GetOnePersonQuery, SR_Person>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetOnePersonQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<SR_Person> Handle(GetOnePersonQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.UPerson.GetOneValue(x=> x.idPerson == request.idPerson, x=> x.City, x=>x.City.Country, x => x.TypeDocument, x => x.Users);
        }
    }
}
