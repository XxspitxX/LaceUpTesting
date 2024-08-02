namespace LaceUpTesting.Views;

public partial class ProductDetailsView : ContentPageBase
{
	public ProductDetailsView(ProductDetailsViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}