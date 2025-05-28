using MediatR;
using SOH.CORE.Interfaces;

namespace SOH.CORE.Features.User
{
    public class GetVerificationUser : IRequest<(string token, string userId)> 
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }

    internal class GetVerificationUserCommon : IRequestHandler<GetVerificationUser, (string token, string userId)>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetVerificationUserCommon(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<(string token, string userId)> Handle(GetVerificationUser request, CancellationToken cancellationToken)
        {
            //Validar si es usuario no esta desactivado
            var result = await _unitOfWork.IUser.GetUserByEmailAsync(request.Email);
            if (result.isActive)
            {
                // Verificación de usuario por el campo tipo de persona
                return await _unitOfWork.IUser.ValidarUserAsync(request.Email, request.PasswordHash);
            }
            return (null, null);
        }
    }
}
