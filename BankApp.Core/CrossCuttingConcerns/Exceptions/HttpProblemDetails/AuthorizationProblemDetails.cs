using System.Net;

namespace BankApp.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    /// <summary>
    /// Yetkilendirme hatalarında dönecek hata detayları.
    /// </summary>
    public class AuthorizationProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public AuthorizationProblemDetails(string detail)
        {
            Title = "Authorization Error";
            Detail = detail;
            Status = StatusCodes.Status401Unauthorized;
            Type = "https://example.com/probs/authorization";
        }
    }
} 