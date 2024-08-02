using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Extensions;
using LaceUpTesting.Models;
using LaceUpTesting.Services.Navigation;
using LaceUpTesting.Storage;
using LaceUpTesting.Storage.Cart;
using LaceUpTesting.ViewModels.Base;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LaceUpTesting.ViewModels
{
    [QueryProperty(nameof(Product), "Product")]
    public partial class ProductDetailsViewModel : ViewModelBase
    {
        [ObservableProperty]
        Product? product;
        private readonly CartDbSource _dbSource;
        [ObservableProperty]
        int? quantity;

        public ProductDetailsViewModel(INavigationService navigationService, CartDbSource dbSource) : base(navigationService)
        {
            _dbSource = dbSource;
            Quantity = 0;
        }

        [RelayCommand]
        public async Task AddCartCommand()
        {
            await IsBusyFor(
             async () =>
             {
                 await _SaveLocalProduct();

             });
        }

        private async Task _SaveLocalProduct()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            string infoText = "Product successfully added to cart.";

            try
            {
                CartDetail? cartDetail;
                Quantity++;
                cartDetail =   await _dbSource.GetItemAsync(Product?.Id);
                if (cartDetail != null)
                {
                    if(Quantity <= cartDetail.Quantity)
                    {
                        Quantity = cartDetail.Quantity;
                        Quantity++;
                    }
                    cartDetail.Quantity = Quantity;
                    await _dbSource.UpdateItemAsync(cartDetail);
                }
                else
                {
                    Quantity = 1;
                    cartDetail = 
                        new CartDetail()
                        {
                            id = ObjectId.NewObjectId(),
                            Product = Product,
                            Quantity = Quantity
                        };
                    
                    await _dbSource.SaveItemAsync(cartDetail);
                }
                      


                _HandleMessage(infoText, cancellationTokenSource);
            }
            catch (Exception ex)
            {
                infoText = "Product failed to added to cart.";
                _HandleMessage(infoText, cancellationTokenSource);

            }

        }


        async void _HandleMessage(String message, CancellationTokenSource cancellationTokenSource)
        {
            ToastDuration duration = ToastDuration.Short;

            var toast = Toast.Make(message, duration);

            await toast.Show(cancellationTokenSource.Token);

        }
    }
}
