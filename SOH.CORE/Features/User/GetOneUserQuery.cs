using MediatR;
using SOH.CORE.Interfaces;
using SOH.MAIN.Models.Users;

namespace SOH.CORE.Features.User
{
    public class GetOneUserQuery : IRequest<SR_Users>
    {
        public string Id { get; set; }
    }

    internal class GetOneUserQueryHandler : IRequestHandler<GetOneUserQuery, SR_Users>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetOneUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<SR_Users> Handle(GetOneUserQuery request, CancellationToken cancellationToken)
        {
            // Obtener los datos del usuario
            return await _unitOfWork.IUser.GetUserAsync(request.Id);
        }
    }
}
