using AutoMapper;
using SOH.CORE.Dto;
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
        // Mapeo de DatosUser a SR_Users
        CreateMap<DatosUser, SR_Users>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.phoneNumber))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ReverseMap();

        // Mapeo de AddPersonCommon a SR_Person
        CreateMap<AddPersonCommon, SR_Person>()
            .ForMember(dest => dest.dateCreation, opt => opt.MapFrom(src => DateTime.Now.ToLocalTime()))
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users))
            .ReverseMap();

        CreateMap<UpdatePersonCommon, SR_Person>()
            .ForMember(dest => dest.dateModify, opt => opt.MapFrom(src => DateTime.Now.ToLocalTime()))
                .ReverseMap();

        // Configuración para mapear un usuario
        CreateMap<AddUserCommon, SR_Users>()
                .ForMember(x => x.dateCreation, y => y.MapFrom(z => DateTime.Now.ToLocalTime()))
                .ReverseMap();

            CreateMap<UpdateUserCommon, SR_Users>()
                .ForMember(x => x.dateModify, y => y.MapFrom(z => DateTime.Now.ToLocalTime()))
                .ForMember(x => x.SecurityStamp, y => y.MapFrom(z => Guid.NewGuid().ToString()))
                .ReverseMap();

            CreateMap<UpdatePasswordCommon, SR_Users>()
                .ForMember(x => x.dateModify, y => y.MapFrom(z => DateTime.Now.ToLocalTime()))
                .ReverseMap();

            CreateMap<IsActiveUserCommon, SR_Users>()
                .ForMember(x => x.dateModify, y => y.MapFrom(z => DateTime.Now.ToLocalTime()))
                .ReverseMap();
        }
    }
}
