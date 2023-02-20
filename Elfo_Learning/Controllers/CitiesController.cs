using System.Net;
using Elfo_Learning.MockData;
using Elfo_Learning.Models;
using Elfo_Learning.Validation;

namespace Elfo_Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private ILogger<CitiesController> logger;
        public CitiesController(ILogger<CitiesController> logger)
        {
            this.logger = logger;
        }
        [HttpGet("get")]
        public async Task<ActionResult<Response>> Get(int id)
        {
            try
            {
                throw new Exception();
                var response = new Response();
                var result = Cities.data.Select(x => x.Id).ToList();
                if (!result.Contains(id))
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Success = false;
                    response.Message = $"There is not existing city";
                    return BadRequest(response);
                }

                response.StatusCode = HttpStatusCode.OK;
                response.Data = Cities.data.FirstOrDefault(p => p.Id == id);
                response.Success = true;
                response.Message = $"Succesfully get {id} city";


                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogCritical("Get error");
                return StatusCode(500, "Happened a server error ");
            }

        }
        [HttpPost("add")]
        public async Task<ActionResult<Response>> AddCity([FromBody] CityDto citydto)
        {
            try
            {
                var response = new Response();
                var validate = new CityValidator();
                var result = validate.Validate(citydto);
                if (!result.IsValid)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Success = false;
                    response.Message = result.Errors;
                    return BadRequest(response);
                }
                response.StatusCode = HttpStatusCode.Created;
                response.Success = true;
                response.Message = $"Succesfully Added city";
                return CreatedAtAction("Get", new { id = citydto.Id }, citydto);
            }
            catch (Exception ex)
            {
                logger.LogCritical("Get error");
                return StatusCode(500, "Happened a server error ");
            }
        }
    }
}
