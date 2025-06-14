using System.Net;

namespace BankApp.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    /// <summary>
    /// İş kuralları ihlallerinde dönecek hata detayları.
    /// </summary>
    public class BusinessProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public BusinessProblemDetails(string detail)
        {
            Title = "Business Rule Violation";
            Detail = detail;
            Status = StatusCodes.Status400BadRequest;
            Type = "https://example.com/probs/business";
        }
    }
} 