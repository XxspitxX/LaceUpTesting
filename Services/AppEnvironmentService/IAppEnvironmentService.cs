using LaceUpTesting.Services.CatalogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaceUpTesting.Services.AppEnvironmentService
{
    public interface IAppEnvironmentService
    {
        ICatalogService? CatalogService { get; }
        void UpdateDependencies();
    }
}
