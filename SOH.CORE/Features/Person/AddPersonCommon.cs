using AutoMapper;
using MediatR;
using SOH.CORE.Interfaces;
using SOH.MAIN.Models.Customer;

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
            var result =  await _unitOfWork.UPerson.AddValue(map);
            await _unitOfWork.SaveChanges();

            return result;
        }
    }
}
