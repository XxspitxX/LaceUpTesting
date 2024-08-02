namespace LaceUpTesting.Views;

public partial class CartCheckoutView : ContentPageBase
{
	public CartCheckoutView(CartViewModel cartViewModel)
	{
		BindingContext = cartViewModel;
		InitializeComponent();
	}
}