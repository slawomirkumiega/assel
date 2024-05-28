using Assel.DTO;
using Assel.Entities;
using AutoMapper;

namespace Assel.Mappers
{
    internal sealed class AutoMapperUserProfile : Profile
    {
        public AutoMapperUserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
