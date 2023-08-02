using CityAPI.Core;
using CityAPI.Core.Dtos.City;
using CityAPI.Services.CityService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CityAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;

        }

        [HttpGet]

        public async Task<ActionResult<ServiceResponse<List<CityEntity>>>> Get()
        {
            return Ok(_cityService.GetAllCity());

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<CityEntity>>> GetSingle(int id)
        {


            return Ok(_cityService.GetAllCityById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<CityEntity>>>> AddCity(AddCity newcity)
        {

            return Ok(await _cityService.AddCity(newcity));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCity>>> UpdateCity(UpdateCity updateCity)
        {
            var response = await _cityService.UpdateCity(updateCity);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCity>>>> DeleteCity (int id)
        {
            var response = await _cityService.DeleteCity(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
