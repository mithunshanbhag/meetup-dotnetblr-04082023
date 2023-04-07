namespace WebApi.Services;

public abstract class WebApiServiceBase
{
    protected readonly IMapper Mapper;

    protected readonly IWeatherRepository WeatherRepository;

    protected WebApiServiceBase(IMapper mapper, IWeatherRepository weatherRepository)
    {
        Mapper = mapper;
        WeatherRepository = weatherRepository;
    }
}