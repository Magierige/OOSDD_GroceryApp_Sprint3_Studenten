using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Grocery.Core.Services;
using System.Collections.ObjectModel;

namespace Grocery.App.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products { get; set; }

        public ProductViewModel(IProductService productService)
        {
            Products = new(productService.GetAll());
        }

        public void addProduct(string productName, int stock)
        {
            //Console.WriteLine($"product naam: {productName} met {stock}");
            var serv = ServiceHelper.GetService<IProductService>();
            int id = Products.Last().Id + 1;
            serv.Add(new Product(id, productName, stock));
        }
    }

    public static class ServiceHelper
    {
        public static T GetService<T>() => Current.GetService<T>();

        public static IServiceProvider Current =>
            IPlatformApplication.Current?.Services
            ?? throw new InvalidOperationException("Services not available");
    }

}
