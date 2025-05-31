using MediatR;
using SOH.CORE.Interfaces;
using SOH.MAIN.Models.Customer;

namespace SOH.CORE.Features.City
{
    public class GetAllCityQuery : IRequest<List<SR_City>>
    {

    }

    internal class GetAllCityQueryCountry : IRequestHandler<GetAllCityQuery, List<SR_City>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllCityQueryCountry(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<SR_City>> Handle(GetAllCityQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.UCity.GetAllValues();
        }
    }
}
