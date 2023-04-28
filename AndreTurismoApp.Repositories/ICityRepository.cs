using AndreTurismoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoApp.Repositories
{
    public interface ICityRepository
    {
        City Insert(City city);
        bool Delete(City city);
        bool Update(City city, int id);
        City GetById(int id);
        List<City> GetAll();
    }
}
