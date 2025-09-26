using Grocery.App.ViewModels;

namespace Grocery.App.Views;

public partial class ProductView : ContentPage
{
    private ProductViewModel VM => (ProductViewModel)BindingContext;
    public ProductView(ProductViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	public async void OnAddClicked(object sender, EventArgs e)
	{
        string name = nameField?.Text?.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            await DisplayAlert("Fout", "Naam is verplicht.", "OK");
            return;
        }

        if (!int.TryParse(stockField?.Text, out int stock) || stock < 0)
        {
            await DisplayAlert("Fout", "Stock moet een niet-negatief getal zijn.", "OK");
            return;
        }

         VM.addProduct(name, stock);

        // DisplayAlert-overloads: (title, message, cancel) of (title, message, accept, cancel)
        await DisplayAlert("Informatie", $"Toegevoegd: {name} (stock: {stock})", "OK");

        // Velden leegmaken (optioneel)
        nameField.Text = string.Empty;
        stockField.Text = string.Empty;
    }
}