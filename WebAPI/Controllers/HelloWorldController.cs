using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        private readonly IHelloWorldService helloWorldService;
        private readonly ILogger<HelloWorldController> logger; // Agrega el logger

        public HelloWorldController(IHelloWorldService helloWorld, ILogger<HelloWorldController> logger)
        {
            this.helloWorldService = helloWorld;
            this.logger = logger;
        }

        public IActionResult Get()
        {
            // Implementa el logdebug
            logger.LogDebug("Obteniendo el texto");

            return Ok(helloWorldService.GetHelloWorld());
        }
    }
}
