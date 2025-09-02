using LemonadeStand.Abstractions.Interfaces;
using LemonadeStand.Abstractions.Models;
using LemonadeStand.Abstractions.Struct;
using Microsoft.AspNetCore.Mvc;

namespace LemonadeStand.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductTypeController : Controller, IProductTypeController
  {
    private readonly ILogger<ProductTypeController> _logger;
    private readonly IProductTypeService _ProductTypeService;

    public ProductTypeController(ILogger<ProductTypeController> logger,
        IProductTypeService ProductTypeService)
    {
      _logger = logger;
      _ProductTypeService = ProductTypeService;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] int id)
    {
      try
      {
        if (string.IsNullOrEmpty(id.ToString()))
        {
          return BadRequest("id is empty");
        }

        _logger.LogInformation(ProductTypeLogMessages.ProductType_INVOKE_DELETE_SERVICE);
        await _ProductTypeService.DeleteAsync(id);
        return Ok();
      }
      catch (Exception ex)
      {
        _logger.LogInformation(ProductTypeLogMessages.ProductType_INVOKE_DELETE_SERVICE_ERROR);
        return StatusCode(500);
      }
    }

    [HttpGet]
    public async Task<ActionResult> GetAllAsync([FromQuery] string search, [FromQuery] int pageIndex, [FromQuery] int pageSize, [FromQuery] string sortField = null)
    {
      try
      {
        if (string.IsNullOrEmpty(search.ToString()))
        {
          return BadRequest("search is empty");
        }

        _logger.LogInformation(ProductTypeLogMessages.ProductType_INVOKE_GETALL_SERVICE);
        var oSize = await _ProductTypeService.GetAllAsync(search, pageIndex, pageSize, sortField);
        return Ok(oSize);
      }
      catch (Exception ex)
      {
        _logger.LogInformation(ProductTypeLogMessages.ProductType_INVOKE_GETALL_SERVICE_ERROR);
        return StatusCode(500);
      }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetByIdAsync([FromRoute] int id)
    {
      try
      {
        if (string.IsNullOrEmpty(id.ToString()))
        {
          return BadRequest("id is empty");
        }

        _logger.LogInformation(ProductTypeLogMessages.ProductType_INVOKE_GETBYID_SERVICE);
        var oSize = await _ProductTypeService.GetByIdAsync(id);
        return Ok(oSize);
      }
      catch (Exception ex)
      {
        _logger.LogInformation(ProductTypeLogMessages.ProductType_INVOKE_GETBYID_SERVICE_ERROR);
        return StatusCode(500);
      }
    }

    [HttpPost]
    public async Task<ActionResult> InsertAsync([FromBody] ProductType ProductType)
    {
      try
      {
        if (string.IsNullOrEmpty(ProductType.Name))
        {
          return BadRequest("name is empty");
        }

        _logger.LogInformation(ProductTypeLogMessages.ProductType_INVOKE_INSERT_SERVICE);
        await _ProductTypeService.InsertAsync(ProductType);
        return Ok();
      }
      catch (Exception ex)
      {
        _logger.LogInformation(ProductTypeLogMessages.ProductType_INVOKE_INSERT_SERVICE_ERROR);
        return StatusCode(500);
      }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromRoute] int id, [FromBody] ProductType ProductType)
    {
      try
      {
        if (string.IsNullOrEmpty(id.ToString()))
        {
          return BadRequest("id is empty");
        }


        _logger.LogInformation(ProductTypeLogMessages.ProductType_INVOKE_UPDATE_SERVICE);
        await _ProductTypeService.UpdateAsync(id, ProductType);
        return Ok();
      }
      catch (Exception ex)
      {
        _logger.LogInformation(ProductTypeLogMessages.ProductType_INVOKE_UPDATE_SERVICE_ERROR);
        return StatusCode(500);
      }
    }
  }
}

