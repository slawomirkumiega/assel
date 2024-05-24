using AutoMapper;
using users.DTO;
using users.Entities;

namespace users.Mappers
{
    internal sealed class AutoMapperUserProfile : Profile
    {
        public AutoMapperUserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login));
        }
    }
}
