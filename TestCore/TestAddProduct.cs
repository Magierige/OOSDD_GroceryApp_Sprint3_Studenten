using NUnit.Framework;
// PAS eventueel aan:
using Grocery.Core.Data;
using Grocery.Core.Data.Repositories;
using Grocery.Core.Models;
using Grocery.Core.Services;

namespace TestCore
{
    [TestFixture]
    public class ProductServiceTests_NoEf
    {
        private ProductRepository _repo = null!;
        private ProductService _service = null!;

        [SetUp]
        public void Setup()
        {
            _repo = new ProductRepository(); // ctor zonder DbContext
            _service = new ProductService(_repo);
        }

        [Test]
        public void Add_AddsToRepositoryAndReturnsSameInstance()
        {
            var product = new Product(0, "Mango", 3);

            var result = _service.Add(product);

            Assert.AreSame(product, result);
            // Controleer dat het item ook in de repo staat
            var all = _repo.GetAll(); // of een vergelijkbare methode
            Assert.That(all, Has.Exactly(1).Matches<Product>(p => p.Name == "Mango" && p.Stock == 3));
        }
    }
}
