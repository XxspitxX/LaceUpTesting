using CommunityToolkit.Mvvm.Messaging;
using LaceUpTesting.Messages;

namespace LaceUpTesting.Views;

public partial class ProductCatalogView : ContentPageBase
{
	public ProductCatalogView(ProductCatalogViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();

 
    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();

    }
}