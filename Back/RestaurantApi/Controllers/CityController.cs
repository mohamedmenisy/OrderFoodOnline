using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApi.DTO;
using RestaurantApi.Interfaces;
using RestaurantApi.Models;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICity cityRepo;

        public CityController(ICity _cityRepo)
        {
            cityRepo = _cityRepo;
        }

        [HttpPost("AddCity")]
        public IActionResult AddCity(CityDTO city)
        {
            if (ModelState.IsValid)
            {

                var mycity= cityRepo.AddCity(city);
                return Ok(mycity);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("GetCities")]
        public IActionResult GetCities() { 
            var allceties = cityRepo.GetAll();
            if (allceties.Count > 0 )
            {
                return Ok(allceties);
            }
            else
            {
                return NotFound(new { message= "Not Found" });
            }
        }
    }
}
