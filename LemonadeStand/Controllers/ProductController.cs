using LemonadeStand.Abstractions.Interfaces;
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

        [HttpGet]
        public async Task<ActionResult> GetProductsAsync()
        {
            try
            {
                var oReturn = await _productService.GetProductsAsync();
                return Ok(oReturn);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}

