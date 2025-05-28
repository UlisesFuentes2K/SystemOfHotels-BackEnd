using AutoMapper;
using MediatR;
using SOH.CORE.Interfaces;
using SOH.MAIN.Models.Users;

namespace SOH.CORE.Features.User
{
    public class AddUserCommon : IRequest<SR_Users>
    {
        public int idPerson { get; set; }
        public int idTipoPersona { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool twoFactorEnabled { get; set; }
        public string phoneNumber { get; set; }
    }

    internal class AddUserCommonHandler : IRequestHandler<AddUserCommon, SR_Users>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddUserCommonHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<SR_Users> Handle(AddUserCommon request, CancellationToken cancellationToken)
        {
            string roleName = "User";

            // Mapear los datos
            var map = _mapper.Map<SR_Users>(request);

            // Configurar propiedades adicionales
            map.isActive = true;
            map.LockoutEnd = DateTimeOffset.UtcNow.AddMinutes(21);
            map.LockoutEnabled = true;
            map.AccessFailedCount = 5;
            if (!string.IsNullOrEmpty(map.PhoneNumber))
                map.PhoneNumberConfirmed = true;

            //Asignar un rol, guardar y retornar datos
            if(request.idTipoPersona != 1)
            {
                roleName = "Employee";
                await _unitOfWork.IUser.AddUserAsync(roleName, map);
            }
            await _unitOfWork.IUser.AddUserAsync(roleName, map);
            return map;
        }
    }
}
