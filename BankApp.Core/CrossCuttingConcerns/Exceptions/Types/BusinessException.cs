namespace BankApp.Core.CrossCuttingConcerns.Exceptions.Types
{
    /// <summary>
    /// İş kuralları ihlallerinde fırlatılacak hata.
    /// </summary>
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {
        }
    }
} 