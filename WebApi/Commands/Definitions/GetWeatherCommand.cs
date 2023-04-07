namespace WebApi.Commands.Definitions;

public class GetWeatherCommand : IRequest<IActionResult>
{
    public string City { get; set; }
}