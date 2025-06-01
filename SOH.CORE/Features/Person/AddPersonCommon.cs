using AutoMapper;
using MediatR;
using SOH.CORE.Dto;
using SOH.CORE.Interfaces;
using SOH.MAIN.Models.Customer;
using SOH.MAIN.Models.Users;

namespace SOH.CORE.Features.Person
{
    public class AddPersonCommon : IRequest<SR_Person>
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

    internal class AddPersonCommonHandler : IRequestHandler<AddPersonCommon, SR_Person>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddPersonCommonHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<SR_Person> Handle(AddPersonCommon request, CancellationToken cancellationToken)
        {
            // Mapear los datos obtenidos
            var map = _mapper.Map<SR_Person>(request);

            // Guardar los datos mapeados
            var result = await _unitOfWork.UPerson.AddValue(map);
            await _unitOfWork.SaveChanges();

            // Configurar propiedades del usuario
            SR_Users user = _mapper.Map<SR_Users>(request.Users);
            user.idPerson = result.idPerson;
            user.isActive = true;
            user.LockoutEnd = DateTimeOffset.UtcNow.AddMinutes(21);
            user.LockoutEnabled = true;
            user.AccessFailedCount = 5;
            user.dateCreation = map.dateCreation;

            // Asignar rol y guardar usuario
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
