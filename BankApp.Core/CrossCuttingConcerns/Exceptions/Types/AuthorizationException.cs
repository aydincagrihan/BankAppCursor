namespace BankApp.Core.CrossCuttingConcerns.Exceptions.Types
{
    /// <summary>
    /// Yetkilendirme hatalarında fırlatılacak hata.
    /// </summary>
    public class AuthorizationException : Exception
    {
        public AuthorizationException(string message) : base(message)
        {
        }
    }
} 