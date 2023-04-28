using AndreTurismoApp.Models;
using AndreTurismoApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {

        private readonly CityService _cityService;
        public CityController(CityService cityService)
        {
            _cityService = cityService;
        }


        [HttpGet]
        public async Task<List<City>> Get()
        {
            return await _cityService.Get();
        }
    }
}
