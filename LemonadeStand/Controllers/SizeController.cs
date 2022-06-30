using LemonadeStand.Abstractions.Interfaces;
using LemonadeStand.Abstractions.Models;
using Microsoft.AspNetCore.Mvc;

namespace LemonadeStand.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LemonadeTypeController : Controller, ILemonadeTypeController
    {
        private readonly ILogger<LemonadeTypeController> _logger;
        private readonly ILemonadeTypeService _lemonadeTypeService;
        private const string LEMONADETYPE_INVOKE_DELETE_SERVICE =   "Invoking service delete method";
        private const string LEMONADETYPE_INVOKE_GETALL_SERVICE =   "Invoking service get all method";
        private const string LEMONADETYPE_INVOKE_GETBYID_SERVICE =  "Invoking service get by id method";
        private const string LEMONADETYPE_INVOKE_INSERT_SERVICE =   "Invoking service insert method";
        private const string LEMONADETYPE_INVOKE_UPDATE_SERVICE =   "Invoking service update method";
        private const string LEMONADETYPE_INVOKE_DELETE_SERVICE_ERROR =     "Error invoking service delete method";
        private const string LEMONADETYPE_INVOKE_GETALL_SERVICE_ERROR =     "Error invoking service get all method";
        private const string LEMONADETYPE_INVOKE_GETBYID_SERVICE_ERROR =    "Error invoking service get by id method";
        private const string LEMONADETYPE_INVOKE_INSERT_SERVICE_ERROR =     "Error invoking service insert method";
        private const string LEMONADETYPE_INVOKE_UPDATE_SERVICE_ERROR =     "Error invoking service update method";

        public LemonadeTypeController(ILogger<LemonadeTypeController> logger,
            ILemonadeTypeService lemonadeTypeService)
        {
            _logger = logger;
            _lemonadeTypeService = lemonadeTypeService;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            try
            {
                if (string.IsNullOrEmpty(id.ToString()))
                {
                    return BadRequest("id is empty");
                }

                _logger.LogInformation(LEMONADETYPE_INVOKE_DELETE_SERVICE);
                await _lemonadeTypeService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(LEMONADETYPE_INVOKE_DELETE_SERVICE_ERROR);
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromRoute] int id, [FromQuery] string search, [FromQuery] int pageIndex, [FromQuery] int pageSize, [FromQuery] string sortField = null)
        {
            try
            {
                if (string.IsNullOrEmpty(id.ToString()))
                {
                    return BadRequest("id is empty");
                }

                if (string.IsNullOrEmpty(search.ToString()))
                {
                    return BadRequest("search is empty");
                }

                _logger.LogInformation(LEMONADETYPE_INVOKE_GETALL_SERVICE);
                var oLemonadeType = await _lemonadeTypeService.GetAll(id, search,  pageIndex, pageSize, sortField);
                return Ok(oLemonadeType);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(LEMONADETYPE_INVOKE_GETALL_SERVICE_ERROR);
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            try
            {
                if (string.IsNullOrEmpty(id.ToString()))
                {
                    return BadRequest("id is empty");
                }

                _logger.LogInformation(LEMONADETYPE_INVOKE_GETBYID_SERVICE);
                var oLemonadeType = await _lemonadeTypeService.GetById(id);
                return Ok(oLemonadeType);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(LEMONADETYPE_INVOKE_GETBYID_SERVICE_ERROR);
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] LemonadeType lemonadeType)
        {
            try
            {
                if (string.IsNullOrEmpty(lemonadeType.Name))
                {
                    return BadRequest("name is empty");
                }

                _logger.LogInformation(LEMONADETYPE_INVOKE_INSERT_SERVICE);
                await _lemonadeTypeService.Insert(lemonadeType);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(LEMONADETYPE_INVOKE_INSERT_SERVICE_ERROR);
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] LemonadeType lemonadeType)
        {
            try
            {
                if (string.IsNullOrEmpty(id.ToString()))
                {
                    return BadRequest("id is empty");
                }


                _logger.LogInformation(LEMONADETYPE_INVOKE_UPDATE_SERVICE);
                await _lemonadeTypeService.Update(id, lemonadeType);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(LEMONADETYPE_INVOKE_UPDATE_SERVICE_ERROR);
                return StatusCode(500);
            }
        }
    }
}

