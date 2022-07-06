using LemonadeStand.Abstractions.Interfaces;
using LemonadeStand.Abstractions.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LemonadeStand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase, IProductController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<ActionResult> GetProductsAsync()
        {
            try
            {
                var oReturn = await _productService.GetAllProductsAsync();
                return Ok(oReturn);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        public Task InsertAsync(Product size)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, Product size)
        {
            throw new NotImplementedException();
        }

        Task<IActionResult> IProductController.GetProductsAsync()
        {
            throw new NotImplementedException();
        }
    }
}

