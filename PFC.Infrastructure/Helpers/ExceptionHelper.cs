namespace PFC.Infrastructure.Helpers;

public class ExceptionHelper : IExceptionHelper
{
    public void CheckArgumentNullException(object param, string paramName)
    {
        if (param == null)
        {
            throw new ArgumentNullException(paramName);
        }
    }

    public void CheckInvalidOperationException(bool check, string message)
    {
        if (check)
        {
            throw new InvalidOperationException(message);
        }
    }

    public void CheckArgumentException(bool check, string message, string parameterName)
    {
        if (check)
        {
            throw new ArgumentException(message, parameterName);
        }
    }
}