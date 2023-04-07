namespace WebApi.Exceptions;

public abstract class WebApiBaseException : Exception
{
    protected WebApiBaseException(string message) : base(message)
    {
    }

    public abstract IActionResult ToActionResult();
}