using BankApp.Core.CrossCuttingConcerns.Exceptions.Types;

namespace BankApp.Core.CrossCuttingConcerns.Exceptions.Handlers
{
    /// <summary>
    /// Hata yakalama işlemlerini yönetecek abstract sınıf.
    /// </summary>
    public abstract class ExceptionHandler
    {
        public Task HandleExceptionAsync(Exception exception) =>
            exception switch
            {
                BusinessException businessException => HandleException(businessException),
                ValidationException validationException => HandleException(validationException),
                AuthorizationException authorizationException => HandleException(authorizationException),
                _ => HandleException(exception)
            };

        protected abstract Task HandleException(BusinessException businessException);
        protected abstract Task HandleException(ValidationException validationException);
        protected abstract Task HandleException(AuthorizationException authorizationException);
        protected abstract Task HandleException(Exception exception);
    }
} 