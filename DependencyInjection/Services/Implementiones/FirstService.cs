using DependencyInjection.Controllers;
using DependencyInjection.Services.Interfaces;

namespace DependencyInjection.Services.Implementiones
{
    public class FirstService
    {
        private readonly ITransient _transient;
        private readonly IScoped _scoped;
        private readonly ISingleton _singleton;
        private readonly ILogger<FirstService> _logger;
        public FirstService(ITransient transientService,
            IScoped scopedService,
            ISingleton singletonService,
            ILogger<FirstService> logger)
        {
            _transient = transientService;
            _scoped = scopedService;
            _singleton = singletonService;
            _logger = logger;
        }
         public void GenrateRequest()
        {
            _logger.LogInformation($"FirstService: {_transient.OperationID}");
            _logger.LogInformation($"FirstService: {_scoped.OperationID}");
            _logger.LogInformation($"FirstService: {_singleton.OperationID}");

        }

    }
}

