using AndreTurismoApp.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace AndreTurismoApp.Repositories
{
    public class CityRepository : ICityRepository
    {
        private string Conn { get; set; }

        public CityRepository()  
        {
            Conn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\USERS\ADM\ONEDRIVE\DOCUMENTOS\ANDRETURISM.MDF;";
        }

        public City Insert(City city)
        {
            var id = 0;
            using (var db = new SqlConnection(Conn))
            {
                id = db.ExecuteScalar<int>(City.INSERT, city);
            }
            city.Id = id;
            return city;
        }

        public bool Delete(City city)
        {
            var status = false;
            using (var db = new SqlConnection(Conn))
            {
                db.Execute(City.DELETE, city);
                status = true;

            }
            return status;
        }

        public bool Update(City city, int id)
        {
            var status = false;
            using (var db = new SqlConnection(Conn))
            {
                
                db.Execute(City.UPDATE, new { @CityName = city.CityName, @Id = id});
                status = true;
            }
            return status;
        }

        public List<City> GetAll()
        {
            using (var db = new SqlConnection(Conn))
            {
                var cities = db.Query<City>(City.GETALL);
                return (List<City>)cities;
            }
        }

        public City? GetById(int id)
        {
            using (var db = new SqlConnection(Conn))
            {
                var city = db.QueryFirstOrDefault<City>(City.GETBYID, new { @Id = id });
                return (City)city;
            }
        }
    }
}
