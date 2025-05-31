using MediatR;
using SOH.CORE.Interfaces;
using SOH.MAIN.Models.Customer;

namespace SOH.CORE.Features.TypeDocument
{
    public class GetTypeDocumentQuery : IRequest<List<SR_TypeDocument>>
    {
    }

    internal class GetTypeDocumentQueryHandler : IRequestHandler<GetTypeDocumentQuery, List<SR_TypeDocument>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetTypeDocumentQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<SR_TypeDocument>> Handle(GetTypeDocumentQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.UTypeDocument.GetAllValues();
        }
    }
}
