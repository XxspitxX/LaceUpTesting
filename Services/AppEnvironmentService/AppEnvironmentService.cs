using LaceUpTesting.Services.CatalogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaceUpTesting.Services.AppEnvironmentService
{
    public class AppEnvironmentService : IAppEnvironmentService
    {
        private readonly ICatalogService? _catalogService;
        public ICatalogService? CatalogService { get; private set; }

        public AppEnvironmentService(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        public void UpdateDependencies()
        {
            CatalogService = _catalogService;
        }
    }
}
