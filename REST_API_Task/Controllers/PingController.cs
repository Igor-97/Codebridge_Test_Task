using Microsoft.AspNetCore.Mvc;

namespace REST_API_Task.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> GetPing()
        {
            return "Dogs house service. Version 1.0.1";
        }
    }
}
