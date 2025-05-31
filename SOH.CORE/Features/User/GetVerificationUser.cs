using MediatR;
using SOH.CORE.Dto;
using SOH.CORE.Interfaces;

namespace SOH.CORE.Features.User
{
    public class GetVerificationUser : IRequest<ValidarUser> 
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }

    internal class GetVerificationUserCommon : IRequestHandler<GetVerificationUser, ValidarUser>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetVerificationUserCommon(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ValidarUser> Handle(GetVerificationUser request, CancellationToken cancellationToken)
        {
            //Validar si es usuario no esta desactivado
            var result = await _unitOfWork.IUser.GetUserByEmailAsync(request.Email);

            if (result.isActive)
            {
                // Verificación de usuario por el campo tipo de persona
                var data =  await _unitOfWork.IUser.ValidarUserAsync(request.Email, request.PasswordHash);

                // Obtener el rol del usuario
                var rol = await _unitOfWork.IUser.GetUserRolesAsync(result);

                // Verificar el tipo de persona que esta iniciando sesión
                var typePerson = await _unitOfWork.UUsers.GetOneValue(x => x.Id == data.userId, x => x.Person);

                // Instanciar e Ingresar datos.
                ValidarUser validar = new();

                validar.Id = data.userId;
                validar.token = data.token;
                validar.idTypePerson = typePerson.Person.idTypePerson;
                validar.idPerson = typePerson.idPerson;

                validar.Rol = rol;

                //Retorno de datos
                return validar;
            }
            return null;
        }
    }
}
