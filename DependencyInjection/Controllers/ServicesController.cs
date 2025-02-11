using DependencyInjection.Services.Implementiones;
using DependencyInjection.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ITransient _transient;
        private readonly IScoped _scoped;
        private readonly ISingleton _singleton;
        private readonly ILogger<ServicesController> _logger;
        private readonly FirstService _firstService;
        public ServicesController(
            ITransient transientService,
            IScoped scopedService,
            ISingleton singletonService,
            ILogger<ServicesController> logger,
            FirstService firstService)
        {
            _transient = transientService;
            _scoped = scopedService;
            _singleton = singletonService;
            _logger = logger;
            _firstService = firstService;
        }

        [HttpGet("operationids")]
       
        public IActionResult GetOperationIDs()
        {
           
            _logger.LogInformation("Hello from Looger");

            _logger.LogInformation($"ITransient: {_transient.OperationID}");   
            _logger.LogInformation($"IScoped: {_scoped.OperationID}");   
            _logger.LogInformation($"ISingleton: {_singleton.OperationID}");

            _firstService.GenrateRequest();

            return Ok();
        }
    }
}
