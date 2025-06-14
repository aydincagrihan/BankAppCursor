using FluentValidation.Results;

namespace BankApp.Core.CrossCuttingConcerns.Exceptions.Types
{
    /// <summary>
    /// Validation hatalarında fırlatılacak hata.
    /// </summary>
    public class ValidationException : Exception
    {
        public IEnumerable<ValidationFailure> Errors { get; }

        public ValidationException(IEnumerable<ValidationFailure> errors) : base("One or more validation errors occurred.")
        {
            Errors = errors;
        }
    }
} 