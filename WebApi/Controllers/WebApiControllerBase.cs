namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public abstract class WebApiControllerBase : ControllerBase
{
    protected readonly ILogger<WebApiControllerBase> Logger;
    protected readonly IMediator Mediator;

    protected WebApiControllerBase(IMediator mediator, ILogger<WebApiControllerBase> logger)
    {
        Mediator = mediator;
        Logger = logger;
    }

    protected async Task<IActionResult> ProcessMessageAsync(IRequest<IActionResult> request)
    {
        try
        {
            return await Mediator.Send(request);
        }
        catch (ValidationException ve)
        {
            Logger.LogWarning(ve.Message);

            return new BadRequestObjectResult(ve.Message);
        }
        catch (WebApiBaseException webEx)
        {
            Logger.LogWarning(webEx.Message);

            return webEx.ToActionResult();
        }
    }
}