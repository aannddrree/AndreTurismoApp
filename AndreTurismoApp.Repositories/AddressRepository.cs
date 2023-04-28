using AndreTurismoApp.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;

namespace AndreTurismoApp.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private string Conn { get; set; }

        public AddressRepository()
        {
            Conn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\USERS\ADM\ONEDRIVE\DOCUMENTOS\ANDRETURISM.MDF;";
        }

        public bool Insert(Address address)
        {
            var status = false;
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                if(new CityRepository().GetById(address.City.Id) == null)
                {
                    address.City = new CityRepository().Insert(address.City);
                }
                db.ExecuteScalar(Address.INSERT, new { @Street = address.Street, @Number = address.Number, @Neighborhood = address.Neighborhood, @PostalCode = address.PostalCode, @IdCity = address.City.Id });
                status = true;
                db.Close();
            }
            return status;
        }

        public bool Delete(Address address)
        {
            var status = false;
            using (var db = new SqlConnection(Conn))
            {
                db.Execute(Address.DELETE, address);
                status = true;

            }
            return status;
        }

        public bool Update(Address address, int id)
        {
            var status = false;
            using (var db = new SqlConnection(Conn))
            {
                db.Execute(Address.UPDATE, new { @Id = id , @Street = address.Street, @Number = address.Number, @Neighborhood = address.Neighborhood, @PostalCode = address.PostalCode, @IdCity = address.City.Id });
                status = true;
            }
            return status;
        }

        public List<Address> GetAll()
        {
            using (var db = new SqlConnection(Conn))
            {
                var addresses = db.Query<Address>(Address.GETALL);
                return (List<Address>)addresses;
            }
        }

        public Address? GetById(int id)
        {
            using (var db = new SqlConnection(Conn))
            {
                var address = db.QueryFirstOrDefault<Address>(Address.GETBYID, new { @Id = id });
                return (Address)address;
            }
        }
    }
}