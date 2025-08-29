using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Pizzadmin.Data;
using Pizzadmin.Models;
using Pizzadmin.Services;

namespace Pizzadmin.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index(string name)
        {
            var products = await _productService.GetProductsAsync();
            ViewData["active"] = "products";
            if(!name.IsNullOrEmpty())
            {
                var filteredProducts = products.Where(fp => fp.Name.ToLower().Contains(name.ToLower())).ToList();
                ViewBag.Name = name;
                return View(filteredProducts);
            }
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new ProductForCreate();
            ViewData["active"] = "products";
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductForCreate model)
        {
            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl
            };

            await _productService.AddProduct(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetProduct(id);

            var model = new ProductForEdit
            {
                Id = id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductForEdit model)
        {
            var product = new Product
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl
            };

            await _productService.UpdateProduct(product);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
