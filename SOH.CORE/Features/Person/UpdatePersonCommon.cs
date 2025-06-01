using AutoMapper;
using MediatR;
using SOH.CORE.Interfaces;
using SOH.MAIN.Models.Customer;

namespace SOH.CORE.Features.Person
{
    public class UpdatePersonCommon : IRequest<SR_Person>
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
        public SR_Contacts? Contacts { get; set; }
    }

    internal class UpdatePersonCommonHandler : IRequestHandler<UpdatePersonCommon, SR_Person>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UpdatePersonCommonHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<SR_Person> Handle(UpdatePersonCommon request, CancellationToken cancellationToken)
        {
            // Mapear los datos obtenidos
            var map = _mapper.Map<SR_Person>(request);

            // Guardar los datos mapeados
            var result = await _unitOfWork.UPerson.UpdateValue(map);
            await _unitOfWork.SaveChanges();

            return result;
        }
    }
}
