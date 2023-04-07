namespace WebApi.Controllers;

public class WeatherController : WebApiControllerBase
{
    public WeatherController(IMediator mediator, ILogger<WeatherController> logger) : base(mediator, logger)
    {
    }

    // Get weather for specified city
    [HttpGet("/cities/{city}")]
    public async Task<IActionResult> Get(string city)
    {
        var command = new GetWeatherCommand
        {
            City = city
        };

        return await ProcessMessageAsync(command);
    }
}