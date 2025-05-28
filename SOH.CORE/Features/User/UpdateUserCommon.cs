using AutoMapper;
using MediatR;
using SOH.CORE.Interfaces;
using SOH.MAIN.Models.Users;

namespace SOH.CORE.Features.User
{
    public class UpdateUserCommon : IRequest<SR_Users>
    {
        public string id { get; set; }
        public int idPerson { get; set; }
        public string email { get; set; }
        public string passwordHash { get; set; }
        public bool twoFactorEnabled { get; set; }
        public string phoneNumber { get; set; }
    }
    internal class UpdateUserCommonHandler : IRequestHandler<UpdateUserCommon, SR_Users>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserCommonHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<SR_Users> Handle(UpdateUserCommon request, CancellationToken cancellationToken)
        {
            // Mapear los datos obtenidos
            var map = _mapper.Map<SR_Users>(request); 

            // Configurar otras propiedades
            if (string.IsNullOrEmpty(map.PhoneNumber))
                map.PhoneNumberConfirmed = false;

            // Actualizar y retornar datos
            await _unitOfWork.IUser.UpdateUserAsync(map);
            return map;
        }
    }
}
