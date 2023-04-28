using AndreTurismoApp.Models;
using AndreTurismoApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private AddressService addressService;
        private CityService cityService;


        public AddressController()
        {
            addressService = new AddressService();
            cityService = new CityService();
        }

        [HttpPost("{cep}")]
        public bool Insert(string cep)
        {
            var dto = PostOfficeService.GetAddress(cep).Result;
            Address address = new()
            {
                Street = dto.Street,
                Number = dto.Number,
                Neighborhood = dto.Neighborhood,
                PostalCode = dto.PostalCode,
                City = new()
                {
                    CityName = dto.City
                }

            };
            /*City city = new();
            if (address.City.Id != 0)
                city = cityService.GetById(address.City.Id);
            else
                city = cityService.Insert(address.City);
            address.City = city;*/

            return addressService.Insert(address);
        }

        [HttpDelete]
        public bool Delete(Address address)
        {
            return addressService.Delete(address);
        }

        [HttpPut]
        public bool Update(Address address, int id)
        {
            return addressService.Update(address, id);
        }

        [HttpGet]
        public List<Address> GetAll()
        {
            return addressService.GetAll();
        }

    }
}
