using System.Net;
using AutoMapper;
using Elfo_Learning.Entities;
using Elfo_Learning.Models;
using Elfo_Learning.Repositories;
using Elfo_Learning.Services;
using Elfo_Learning.Validation;

namespace Elfo_Learning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private ILogger<CitiesController> logger;
        private IMailService mailService;
        private IMapper mapper;
        private ICityRepository _cityRepository;
        public CitiesController(ILogger<CitiesController> logger, IMailService mailService, IMapper mapper, ICityRepository cityRepository)
        {
            this.logger = logger;
            this.mailService = mailService;
            this.mapper = mapper;
            _cityRepository = cityRepository;
        }
        [HttpGet("get")]
        public async Task<ActionResult<Response>> Get(int id)
        {
            try
            {
                //throw new Exception();
                var response = new Response();
                var result = _cityRepository.Get(p => p.Id == id); /*Cities.data.Select(x => x.Id).ToList();*/
                if (result == null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Success = false;
                    response.Message = $"There is not existing city";
                    return BadRequest(response);
                }

                response.StatusCode = HttpStatusCode.OK;
                response.Data = result/*Cities.data.FirstOrDefault(p => p.Id == id)*/;
                response.Success = true;
                response.Message = $"Succesfully get {id} city";

                //mailService.Send("GetCityFromId","We get city from his id");
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogCritical("Get error");
                return StatusCode(500, "Happened a server error ");
            }

        }
        [HttpGet("getall")]
        public async Task<ActionResult<Response>> GetAll()
        {
            try
            {
                //throw new Exception();
                var response = new Response();
                var result = _cityRepository.GetAll(); /*Cities.data.Select(x => x.Id).ToList();*/
                if (result == null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Success = false;
                    response.Message = $"There is not existing city";
                    return BadRequest(response);
                }

                response.StatusCode = HttpStatusCode.OK;
                response.Data = result/*Cities.data.FirstOrDefault(p => p.Id == id)*/;
                response.Success = true;
                response.Message = $"Succesfully get all cities";

                //mailService.Send("GetCityFromId","We get city from his id");
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogCritical("Get error");
                return StatusCode(500, "Happened a server error ");
            }

        }
        [HttpPost("add")]
        public async Task<ActionResult<Response>> AddCity([FromBody] CityCreateDto citydto)
        {
            try
            {
                var response = new Response();
                var validate = new CityCreateValidator();
                var result = validate.Validate(citydto);
                if (!result.IsValid)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Success = false;
                    response.Message = result.Errors;

                    return BadRequest(response);
                }
                var gen = mapper.Map<City>(citydto);
                await _cityRepository.AddAsync(gen);
                response.StatusCode = HttpStatusCode.Created;
                response.Success = true;
                response.Message = $"Succesfully Added city";
                return CreatedAtAction("Get", new { name = citydto.Name }, citydto);
            }
            catch (Exception ex)
            {
                logger.LogCritical("Get error");
                return StatusCode(500, "Happened a server error ");
            }
        }
        [HttpPut("update")]
        public async Task<ActionResult<Response>> UpdateCity(int id, [FromBody] CityUpdateDto citydto)
        {
            try
            {
                var response = new Response();
                var city = await _cityRepository.Get(p => p.Id == id);
                if (city == null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Success = false;
                    response.Message = "It is not possible to update";

                    return BadRequest(response);
                }
                var gen = mapper.Map<City>(citydto);
                await _cityRepository.UpdateAsync(gen);
                response.StatusCode = HttpStatusCode.OK;
                response.Success = true;
                response.Message = $"Succesfully Updated city";
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogCritical("Get error");
                return StatusCode(500, "Happened a server error ");
            }
        }
        [HttpDelete("delete")]
        public async Task<ActionResult<Response>> DeleteCity(int id)
        {
            try
            {
                var response = new Response();
                var city =await  _cityRepository.Get(p => p.Id == id);
                if (city == null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Success = false;
                    response.Message = "It is not possible to delete";

                    return BadRequest(response);
                }
                await _cityRepository.DeleteAsync(city);
                response.StatusCode = HttpStatusCode.OK;
                response.Success = true;
                response.Message = $"Succesfully Deleted city";
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogCritical("Get error");
                return StatusCode(500, "Happened a server error ");
            }
        }
    }
}
