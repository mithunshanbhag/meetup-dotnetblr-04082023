namespace WebApi.Exceptions;

public class WeatherNotFoundException : WebApiBaseException
{
    public WeatherNotFoundException(string city) : base($"Weather for city '{city}' not found.")
    {
    }

    public override IActionResult ToActionResult()
    {
        return new NotFoundObjectResult(Message);
    }
}