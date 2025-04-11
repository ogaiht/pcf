namespace PFC.Infrastructure.Helpers;

public interface IExceptionHelper
{
    void CheckArgumentNullException(object param, string paramName);
    void CheckInvalidOperationException(bool check, string message);
    void CheckArgumentException(bool check, string message, string parameterName);
}