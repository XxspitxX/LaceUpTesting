using LaceUpTesting.Models;
using LaceUpTesting.Services.RequestProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaceUpTesting.Services.CatalogService
{
    public class CatalogService : ICatalogService
    {
        private readonly IRequestProvider _requestProvider;

        private const string urlProduct = "https://fakestoreapi.com/products";

        public CatalogService(IRequestProvider requestProvider) { 
            _requestProvider = requestProvider;
        }
        public async Task<IEnumerable<Product>?> GetProductsAsync()
        {
            return await _requestProvider.GetAsync<IEnumerable<Product>?>(urlProduct);
        }
    }
}
