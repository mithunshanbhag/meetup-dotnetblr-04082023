namespace WebApi.Services.Interfaces;

public interface IWeatherService
{
    Task<WeatherDto> GetWeatherAsync(string city, CancellationToken cancellationToken = default);
}