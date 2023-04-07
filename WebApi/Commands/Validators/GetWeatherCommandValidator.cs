namespace WebApi.Commands.Validators;

public class GetWeatherCommandValidator : AbstractValidator<GetWeatherCommand>
{
    public GetWeatherCommandValidator()
    {
        RuleFor(command => command.City).NotEmpty().MinimumLength(3).MaximumLength(50);
    }
}