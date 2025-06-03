using AutoMapper;
using MediatR;
using OneOf;
using SOH.CORE.Dto;
using SOH.CORE.Interfaces;
using SOH.MAIN.Models.Customer;
using SOH.MAIN.Models.Users;

namespace SOH.CORE.Features.Person
{
    public class AddPersonCommon : IRequest<OneOf<SR_Person, string>>
    {
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

    internal class AddPersonCommonHandler : IRequestHandler<AddPersonCommon, OneOf<SR_Person, string>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddPersonCommonHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<OneOf<SR_Person, string>> Handle(AddPersonCommon request, CancellationToken cancellationToken)
        {
            // Mapear los datos obtenidos
            var map = _mapper.Map<SR_Person>(request);

            // Validar restricciones en datos de una persona
            var person = await _unitOfWork.UPerson.GetOneValue(x => x.numberDocument == map.numberDocument &&
                                                                x.idTypeDocument == map.idTypeDocument);

            // Configurar propiedades del usuario
            var user = _mapper.Map<SR_Users>(request.Users);

            // Validar si el usuario es el mimo o es otro
            if (person != null) return "Ya hay un usuario con el documento de identificación";

            // validar e insertar datos del nuevo usuario
            var existe = await _unitOfWork.IUserV.GetOneValue(x => x.Email == user.Email);
            if (existe != null) return "El email ingresado ya pertenece a una cuenta";

            // Guardar los datos mapeados
            var result = await _unitOfWork.UPerson.AddValue(map);
            await _unitOfWork.SaveChanges();

            // Asignar rol y guardar usuario
            user.idPerson = result.idPerson;
            string roleName = request.idTypePerson != 1 ? "Employee" : "User";
            await _unitOfWork.IUser.AddUserAsync(roleName, user);

            // Guardar contactos si existen
            if (request.Contacts != null)
            {
                request.Contacts.idPerson = map.idPerson;
                await _unitOfWork.UContacts.AddValue(request.Contacts);
            }

            return result;
        }
    }
}
