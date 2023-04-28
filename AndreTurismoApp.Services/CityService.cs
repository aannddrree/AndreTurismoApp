using AndreTurismoApp.Models;
using AndreTurismoApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoApp.Services
{
    public class CityService
    {
        public ICityRepository cityRepository;

        public CityService()
        {
            cityRepository = new CityRepository();
        }

        public City Insert(City city)
        {
            return cityRepository.Insert(city);
        }

        public bool Delete(City city)
        {
            return cityRepository.Delete(city);
        }

        public bool Update(City city, int id)
        {
            return cityRepository.Update(city, id);
        }

        public List<City> GetAll()
        {
            return cityRepository.GetAll();
        }

        public City GetById(int id)
        {
            return cityRepository.GetById(id);
        }
    }
}
