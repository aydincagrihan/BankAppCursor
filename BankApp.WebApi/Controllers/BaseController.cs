using Microsoft.AspNetCore.Mvc;

namespace BankApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult HandleError(Exception exception)
        {
            return exception switch
            {
                _ => StatusCode(500, new { error = "An unexpected error occurred." })
            };
        }
    }
} 