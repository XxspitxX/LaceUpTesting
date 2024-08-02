using LaceUpTesting.Services.Navigation;
using LaceUpTesting.Views;

namespace LaceUpTesting
{
    public partial class AppShell : Shell
    {
        private readonly INavigationService _navigationService;
        public AppShell(INavigationService navigationService)
        {
            _navigationService = navigationService;
            AppShell.InitializeRouting();
            InitializeComponent();
        }

        protected override async void OnHandlerChanged()
        {
            base.OnHandlerChanged();
            if (Handler is not null)
            {
                await _navigationService.InitializeAsync();
            }
        }
        private static void InitializeRouting()
        {
            Routing.RegisterRoute("Cart", typeof(CartCheckoutView));

            Routing.RegisterRoute("Catalog", typeof(ProductCatalogView));
            Routing.RegisterRoute("ProductDetail", typeof(ProductDetailsView));
            
        }
    }
}
