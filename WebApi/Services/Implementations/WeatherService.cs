namespace WebApi.Services.Implementations;

public class WeatherService : WebApiServiceBase, IWeatherService
{
    public WeatherService(IMapper mapper, IWeatherRepository weatherRepository) : base(mapper, weatherRepository)
    {
    }

    public async Task<WeatherDto> GetWeatherAsync(string city, CancellationToken cancellationToken = default)
    {
        var fakeWeatherDto = new WeatherDto
        {
            City = city,
            TemperatureC = 20
        };

        return await Task.FromResult(fakeWeatherDto);
    }
}