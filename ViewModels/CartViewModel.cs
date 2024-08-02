using CommunityToolkit.Maui.Core.Extensions;
using LaceUpTesting.Models;
using LaceUpTesting.Services.AppEnvironmentService;
using LaceUpTesting.Services.Navigation;
using LaceUpTesting.Storage.Cart;
using LaceUpTesting.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaceUpTesting.ViewModels
{
    public partial class CartViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ObservableCollection<CartDetail>? cartDetails;

        private readonly CartDbSource _cartDbSource;
        public CartViewModel(CartDbSource cartDbSource, INavigationService navigationService) : base(navigationService)
        {
            _cartDbSource = cartDbSource;
        }

        public override async Task InitializeAsync()
        {
            await IsBusyFor(
              async () =>
              {
                  CartDetails?.Clear();
                  
                  CartDetails = await _cartDbSource.GetItemsAsync();

              });
        }


        [RelayCommand]
        public async Task IncremeantQualityCommand(CartDetail? item)
        {
            item!.Quantity++;
            await _cartDbSource.UpdateItemAsync(item);
        }

        [RelayCommand]
        public async Task DecremeantQualityCommand(CartDetail? item)
        {
            try
            {
                item!.Quantity--;
                if (item.Quantity == 0)
                {

                    await _cartDbSource.DeleteItemAsync(item.Product.Id);
                    CartDetails?.Remove(item!);
                }
                else
                {
                    await _cartDbSource.UpdateItemAsync(item);
                }
            }
            catch (Exception ex)
            {

                
            }
           

        }
    }
}
