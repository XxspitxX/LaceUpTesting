using LaceUpTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaceUpTesting.Services.CatalogService
{
    public interface ICatalogService
    {
        Task<IEnumerable<Product>?> GetProductsAsync();
    }
}
