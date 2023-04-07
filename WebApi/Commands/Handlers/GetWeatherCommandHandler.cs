namespace WebApi.Commands.Handlers;

public class GetWeatherCommandHandler : IRequestHandler<GetWeatherCommand, IActionResult>, IRequestPreProcessor<GetWeatherCommand>
{
    private readonly IWeatherService _weatherService;

    public GetWeatherCommandHandler(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public async Task<IActionResult> Handle(GetWeatherCommand command, CancellationToken cancellationToken)
    {
        var city = command.City;

        var weatherDto = await _weatherService.GetWeatherAsync(city, cancellationToken);

        return new OkObjectResult(weatherDto);
    }

    public async Task Process(GetWeatherCommand command, CancellationToken cancellationToken)
    {
        var validator = new GetWeatherCommandValidator();

        await validator.ValidateAndThrowAsync(command, cancellationToken);
    }
}