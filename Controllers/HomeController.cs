using Microsoft.AspNetCore.Mvc;

namespace Blog2811.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok(new {
                teste = "ok"
            });
        }
    }
}