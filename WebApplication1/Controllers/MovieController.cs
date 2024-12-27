using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class MovieController: ControllerBase
{
    [HttpGet]
    public IActionResult GetMovies()
    {
        return Ok(new List<object>()
        {
            new
            {
                Name = "Zena: King of Warriors",
                Duration = TimeSpan.FromHours(1),
            },
            new
            {
                Name = "The best movie",
                Duration = TimeSpan.FromHours(5),
            },
        });
    }
}