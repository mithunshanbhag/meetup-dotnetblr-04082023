namespace WebApi.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        #region DAO (storage model) to DTO (API/REST model) conversion

        CreateMap<WeatherDao, WeatherDto>()
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.id));

        #endregion

        #region DTO (API/REST model) to DAO (storage model) conversion

        CreateMap<WeatherDto, WeatherDao>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.City));

        #endregion
    }
}