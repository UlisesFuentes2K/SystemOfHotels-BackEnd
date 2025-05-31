using MediatR;
using SOH.CORE.Interfaces;
using SOH.MAIN.Models.Customer;

namespace SOH.CORE.Features.Country
{
    public class GetAllCountryQuery : IRequest<List<SR_Country>>
    {

    }

    internal class GetAllCountryQueryHandler : IRequestHandler<GetAllCountryQuery, List<SR_Country>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllCountryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<SR_Country>> Handle(GetAllCountryQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.UCountry.GetAllValues();
        }
    }
}
