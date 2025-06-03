using AutoMapper;
using MediatR;
using OneOf;
using SOH.CORE.Dto;
using SOH.CORE.Interfaces;
using SOH.MAIN.Models.Customer;
using SOH.MAIN.Models.Users;

namespace SOH.CORE.Features.Person
{
    public class UpdatePersonCommon : IRequest<OneOf<SR_Person, string>>
    {
        public int idPerson { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string direction { get; set; }
        public int idGender { get; set; }
        public int idTypeDocument { get; set; }
        public string numberDocument { get; set; }
        public int idCity { get; set; }
        public int idTypePerson { get; set; }
        public DatosUser Users { get; set; }
        public SR_Contacts? Contacts { get; set; }
    }

    internal class UpdatePersonCommonHandler : IRequestHandler<UpdatePersonCommon, OneOf<SR_Person, string>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UpdatePersonCommonHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<OneOf<SR_Person, string>> Handle(UpdatePersonCommon request, CancellationToken cancellationToken)
        {
            // Mapear los datos obtenidos
            var map = _mapper.Map<SR_Person>(request);

            // Configurar propiedades del usuario
            var users = _mapper.Map<SR_Users>(request.Users);
            users.Person = map;
            //users.Person = map;

            // Validar datos de persona
            var person = await _unitOfWork.UPerson.GetOneValue(x => x.numberDocument == map.numberDocument &&
                                                                x.idTypeDocument == map.idTypeDocument);
            if (person != null)
            {
                if (person.idPerson != request.idPerson) return "El documento de identificación ya esta registrado";
            }

            // Validar datos de Usuario
            var existe = await _unitOfWork.IUserV.GetOneValue(x => x.Email == users.Email);

            if (existe != null)
            {
                if (existe.Id != users.Id) return "El Email ingresado ya esta registrado";
            }

            // Guardar los datos de la persona
            var result = await _unitOfWork.UPerson.UpdateValue(map);
            await _unitOfWork.SaveChanges();

            // Guardar los datos del usuario
            var estate = await _unitOfWork.IUser.UpdateUserAsync(users);
            if (estate == null) return "Error al actualizar los datos del usuario";

            return result;
        }
    }
}
