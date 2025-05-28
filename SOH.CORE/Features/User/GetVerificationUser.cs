using AutoMapper;
using MediatR;
using SOH.CORE.Interfaces;
using SOH.MAIN.Models.Users;

namespace SOH.CORE.Features.User
{
    public class GetVerificationUser : IRequest<(string token, string userId)> 
    {
        public string correo { get; set; }
        public string password { get; set; }
    }

    internal class GetVerificationUserCommon : IRequestHandler<GetVerificationUser, (string token, string userId)>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetVerificationUserCommon(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<(string token, string userId)> Handle(GetVerificationUser request, CancellationToken cancellationToken)
        {
            //Validar si es usuario no esta desactivado
            var result = await _unitOfWork.IUser.GetUserByEmailAsync(request.correo);
            if (result.isActive)
            {
                // Verificación de usuario por el campo tipo de persona
                return await _unitOfWork.IUser.ValidarUserAsync(request.correo, request.password);
            }
            return (null, null);
        }
    }
}
