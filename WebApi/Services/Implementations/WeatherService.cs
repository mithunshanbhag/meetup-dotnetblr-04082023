namespace WebApi.Services.Implementations;

public class WeatherService : WebApiServiceBase, IWeatherService
{
    private readonly ILogger<WeatherService> _logger;

    public WeatherService(IMapper mapper, IWeatherRepository weatherRepository, ILogger<WeatherService> logger) : base(mapper, weatherRepository)
    {
        _logger = logger;
    }

    public async Task<WeatherDto> GetWeatherAsync(string city, CancellationToken cancellationToken = default)
    {
        var weatherDao = await WeatherRepository.GetAsync(city, city, cancellationToken);

        if (weatherDao is null) throw new WeatherNotFoundException(city);

        var weatherDto = Mapper.Map<WeatherDto>(weatherDao);

        _logger.LogInformation($"Successfully extracted weather for city: {city}.");

        return weatherDto;
    }
}