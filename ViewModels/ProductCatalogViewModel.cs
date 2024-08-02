using CommunityToolkit.Maui.Core.Extensions;
using LaceUpTesting.Models;
using LaceUpTesting.Services.AppEnvironmentService;
using LaceUpTesting.Services.Navigation;
using LaceUpTesting.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaceUpTesting.ViewModels
{


    public partial class ProductCatalogViewModel : ViewModelBase
    {

        [ObservableProperty]
        public ObservableCollection<Product>? products;

        [ObservableProperty]
        private Product? selectedProduct;

        private readonly IAppEnvironmentService _appEnvironmentService;
        public ProductCatalogViewModel(IAppEnvironmentService appEnvironmentService ,INavigationService navigationService) : base(navigationService)
        {
            _appEnvironmentService = appEnvironmentService;
        }

        public override async Task InitializeAsync()
        {
            await IsBusyFor(
               async () =>
               {
                   Products?.Clear();
                   IEnumerable<Product>? _products = await _appEnvironmentService.CatalogService.GetProductsAsync();
                   Products = _products?.ToObservableCollection<Product>();

               });
        }

        [RelayCommand]
        public async Task GoToDetailCommand(Product product)
        {
            await IsBusyFor(
               async () =>
               {
                   if (product == null)
                   {
                       return;
                   }

                   var navigationParameter = new Dictionary<string, object>
                    {
                        { "Product", product },
                    };


                   await NavigationService.NavigateToAsync(route : "ProductDetail", routeParameters: navigationParameter);

               });
          
        }
    }
}
