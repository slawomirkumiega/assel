using Assel.ApiDto;
using Assel.Entities;
using AutoMapper;

namespace Assel.Mappers
{
    internal sealed class AutoMapperFactApiProfile : Profile
    {
        public AutoMapperFactApiProfile()
        {
            CreateMap<FactApiDto, Fact>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src._Id))                
                .ForMember(dest => dest.FactText, opt => opt.MapFrom(src => src.Text))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.PetType, opt => opt.MapFrom(src => src.Type));
        }
    }
}
