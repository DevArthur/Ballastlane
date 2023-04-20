using Ballastlane.Business.Services;
using Ballastlane.Data.Models.Entities;
using Ballastlane.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ballastlane.Mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<Product> _repository;
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IRepository<Product> repository,
            IProductService productService)
        {
            _repository = repository;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Products()
        {
            var products = await _repository.Get();
            if (products == null)
            {
                TempData["error"] = "Product not found.";
                return RedirectToAction("ErrorView", "Product");
            }
            return View(products);
        }

        [HttpGet]
        public IActionResult ProductView()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Product(int id)
        {
            var product = await _repository.GetById(id);
            if (product == null)
            {
                TempData["error"] = "Product not found.";
                return RedirectToAction("ErrorView", "Product");
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult CreateView()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ProductCreated()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Product product)
        {
            // Is a valid model?
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Invalid Information.";
                return RedirectToAction("ErrorView", "Product");
            }

            _productService.ApplyPercentageByProductType(product);
            await _repository.Create(product);
            await _repository.Save();
            return RedirectToAction("ProductCreated", "Product");
        }

        [HttpGet]
        public IActionResult UpdateView()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ProductUpdated()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] Product product)
        {
            // Is a valid model?
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Invalid Information.";
                return RedirectToAction("ErrorView", "Product");
            }

            // Does the product exists?
            var productToUpdate = await _repository.GetById(product.Id);
            if (productToUpdate == null)
            {
                TempData["error"] = "Product not found.";
                return RedirectToAction("ErrorView", "Product");
            }

            // Is trying to update the product type?
            var isProductTypeUpdated =
                _productService.IsTypeProductUpdating(productToUpdate.Type, product.Type);
            if (isProductTypeUpdated)
            {
                TempData["error"] = "Is not allowed update the product type.";
                return RedirectToAction("ErrorView", "Product");
            }

            // Recalculate the selling price based on product type.
            _productService.ApplyPercentageByProductType(product);
            _repository.Update(product);
            await _repository.Save();
            return RedirectToAction("ProductUpdated", "Product");
        }

        [HttpGet]
        public IActionResult DeleteView()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ProductDeleted()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _repository.GetById(id);
            if (product == null)
            {
                TempData["error"] = "Product not found.";
                return RedirectToAction("ErrorView", "Product");
            }
            await _repository.Delete(id);
            await _repository.Save();
            return RedirectToAction("ProductDeleted", "Product");
        }

        [HttpGet]
        public IActionResult ErrorView()
        {
            return View();
        }
    }
}