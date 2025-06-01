using MediatR;
using SOH.CORE.Dto;
using SOH.CORE.Interfaces;
using SOH.MAIN.Models.Customer;

namespace SOH.CORE.Features.RegisterGet
{
    public class GetRegisterQuery : IRequest<RegisterData> {}

    internal class GetRegisterQueryHandler : IRequestHandler<GetRegisterQuery, RegisterData>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetRegisterQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<RegisterData> Handle(GetRegisterQuery request, CancellationToken cancellationToken)
        {
            // Instanciar los datos a devolver
            RegisterData data = new();

            try
            {
                data.Country = await _unitOfWork.UCountry.GetAllValues();
                data.City = await _unitOfWork.UCity.GetAllValues();
                data.Gender = await _unitOfWork.UGender.GetAllValues();
                data.TypeDocument = await _unitOfWork.UTypeDocument.GetAllValues();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener datos de registro", ex);
            }

            return data;
        }
    }
}
