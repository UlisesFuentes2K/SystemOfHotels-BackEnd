using AutoMapper;
using SOH.CORE.Features.Person;
using SOH.CORE.Features.User;
using SOH.MAIN.Models.Customer;
using SOH.MAIN.Models.Users;

namespace SOH.PERSISTENCE.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Configuración para mapear una persona
            CreateMap<AddPersonCommon, SR_Person>()
                .ForMember(x=> x.dateCreation, y=> y.MapFrom(z=> DateTime.Now.ToLocalTime()))
                .ReverseMap();
            CreateMap<UpdatePersonCommon, SR_Person>()
                .ForMember(x => x.dateModify, y => y.MapFrom(z => DateTime.Now.ToLocalTime()))
                .ReverseMap();

            // Configuración para mapear un usuario
            CreateMap<AddUserCommon, SR_Users>()
                .ForMember(x => x.dateCreation, y => y.MapFrom(z => DateTime.Now.ToLocalTime()))
                .ReverseMap();
            CreateMap<UpdateUserCommon, SR_Users>()
                .ForMember(x => x.dateModify, y => y.MapFrom(z => DateTime.Now.ToLocalTime()))
                .ForMember(x => x.SecurityStamp, y => y.MapFrom(z => Guid.NewGuid().ToString()))
                .ReverseMap();
        }
    }
}
