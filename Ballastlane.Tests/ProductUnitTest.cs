using Ballastlane.Business.Services;
using Ballastlane.Data.Models.Entities;
using Ballastlane.Data.Repositories;
using Ballastlane.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Ballastlane.Tests
{
    [TestFixture]
    public class ProductUnitTest
    {
        private readonly Mock<IRepository<Product>> _repository;
        private readonly Mock<IProductService> _productService;
        private readonly ProductController _productController;
        private readonly List<Product> productsList;
        private readonly Product product;

        public ProductUnitTest()
        {
            _repository = new Mock<IRepository<Product>>();
            _productService = new Mock<IProductService>();
            _productController = new ProductController(_repository.Object, _productService.Object);

            productsList = new List<Product>() {
                new Product
                {
                    Id = 1,
                    Name = "Cerveza",
                    Brand = "Guiness",
                    Type = "International",
                    Price = 5,
                    SellingPrice = 5.6M
                },

                new Product
                {
                    Id = 2,
                    Name = "Cerveza",
                    Brand = "Corona",
                    Type = "National",
                    Price = 3.5M,
                    SellingPrice = 3.8M
                },

                new Product
                {
                    Id = 3,
                    Name = "Jugo",
                    Brand = "Jumex",
                    Type = "National",
                    Price = 3M,
                    SellingPrice = 3.3M
                }
            };

            product = new Product
            {
                Id = 1,
                Name = "Cerveza",
                Brand = "Guiness",
                Type = "International",
                Price = 5,
                SellingPrice = 5.6M
            };
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Get_WhenCalled_ReturnTaskOfIActionResult()
        {
            var task = Task.FromResult<IEnumerable<Product>>(productsList);
            _repository.Setup(x => x.Get()).Returns(task);

            // Execution
            var products = _productController.Products();

            // Assertions
            Assert.That(products, Is.TypeOf<Task<IActionResult>>());
        }

        [Test]
        public void GetById_WhenCalled_ReturnTaskOfIActionResult()
        {
            var id = 1;
            var task = Task.FromResult(product);
            _repository.Setup(x => x.GetById(id)).Returns(task);

            var productExpected = _productController.Product(id);

            Assert.That(productExpected, Is.TypeOf<Task<IActionResult>>());
        }

        [Test]
        public void Create_WhenCalled_ReturnTaskOfIActionResult()
        {
            var task = Task.FromResult(product);
            _repository.Setup(x => x.Create(product)).Returns(task);
            _repository.Setup(x => x.Save());

            var productCreated = _productController.Create(product);

            Assert.That(productCreated, Is.TypeOf<Task<IActionResult>>());
        }

        [Test]
        public void Update_WhenCalled_ReturnTaskOfIActionResult()
        {
            var id = 1;
            var task = Task.FromResult(product);
            _repository.Setup(x => x.GetById(id)).Returns(task);
            _repository.Setup(x => x.Update(product));
            _repository.Setup(x => x.Save());

            var productUpdated = _productController.Update(product);

            Assert.That(productUpdated, Is.TypeOf<Task<IActionResult>>());
        }

        [Test]
        public void Delete_WhenCalled_ReturnTaskOfIActionResult()
        {
            {
                var id = 1;
                var task = Task.FromResult(product);
                _repository.Setup(x => x.GetById(id)).Returns(task);
                _repository.Setup(x => x.Delete(id));
                _repository.Setup(x => x.Save());

                var productDeleted = _productController.Delete(id);

                Assert.That(productDeleted, Is.TypeOf<Task<IActionResult>>());
            }
        }
    }
}