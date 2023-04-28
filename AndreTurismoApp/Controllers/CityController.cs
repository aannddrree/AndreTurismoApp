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
        private CityService cityService;

        public CityController()
        {
            cityService = new CityService();
        }
        [HttpPost]
        public City Insert(City city)
        {
            return cityService.Insert(city);
        }

        [HttpDelete]
        public bool Delete(City city)
        {
            return cityService.Delete(city);
        }

        [HttpPut]
        public bool Update(City city, int id)
        {
            return cityService.Update(city, id);
        }


        [HttpGet]
        public List<City> GetAll()
        {
            return cityService.GetAll();
        }
    }
}

