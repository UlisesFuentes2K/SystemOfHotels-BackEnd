using MediatR;
using SOH.CORE.Interfaces;

namespace SOH.CORE.Features.User
{
    public class GetVerificationUser : IRequest<(string token, string userId, int idTypePerson)> 
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }

    internal class GetVerificationUserCommon : IRequestHandler<GetVerificationUser, (string token, string userId, int idTypePerson)>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetVerificationUserCommon(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<(string token, string userId, int idTypePerson)> Handle(GetVerificationUser request, CancellationToken cancellationToken)
        {
            //Validar si es usuario no esta desactivado
            var result = await _unitOfWork.IUser.GetUserByEmailAsync(request.Email);

            if (result.isActive)
            {
                // Verificación de usuario por el campo tipo de persona
                var data =  await _unitOfWork.IUser.ValidarUserAsync(request.Email, request.PasswordHash);

                // Verificar el tipo de persona que esta iniciando sesión
                var typePerson = await _unitOfWork.UUsers.GetOneValue(x => x.Id == data.userId, x => x.Person);

                //Retorno de datos
                return (data.token,  data.userId, typePerson.Person.idTypePerson);
            }
            return (null, null, 0);
        }
    }
}
