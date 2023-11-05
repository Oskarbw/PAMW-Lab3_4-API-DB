using Microsoft.AspNetCore.Mvc;

namespace PAMW3_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParcelsController : ControllerBase
    {   
        private readonly ParcelsService _parcelsService;
        private readonly ILogger<ParcelsController> _logger;

        public ParcelsController(ILogger<ParcelsController> logger, ParcelsService parcelsService)
        {
            _logger = logger;
            _parcelsService = parcelsService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
           var result = _parcelsService.ReadAll();
            if (result.IsSuccessful)
            {
                return Ok(result.Data);
            }
            else
            {
                return StatusCode(500, result.ErrorMessage);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id)
        {
           var result = _parcelsService.Read(id);
            if (result.IsSuccessful)
            {
                return Ok(result.Data);
            }
            else
            {
                return StatusCode(404, result.ErrorMessage);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Parcel parcel)
        {
            var result = _parcelsService.Create(parcel);
            if (result.IsSuccessful)
            {
                var id = result.Data.Id;
                return Created($"/api/Parcels/{id}", result.Data);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]int id, [FromBody]Parcel parcel)
        {
            var result = _parcelsService.Update(id, parcel);
            if (result.IsSuccessful)
            {
                return Ok(result.Data);
            }
            else
            {
                return NotFound(result.ErrorMessage);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var result = _parcelsService.Delete(id);
            if (result.IsSuccessful)
            {
                return NoContent();
            }
            else
            {
                return NotFound(result.ErrorMessage);
            }
        }
    }
}