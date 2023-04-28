namespace AndreTurismoApp.Models
{
    public class Address
    {

        public readonly static string INSERT = "Insert into Address (Street, Number, Neighborhood, PostalCode, IdCity)" +
                        "values (@Street, @Number, @Neighborhood, @PostalCode, @IdCity)";
        public readonly static string GETALL = "select * from Address ad, City c where ad.IdCity = c.Id";
        public readonly static string GETBYID = "select ad.Id, ad.Street, ad.Number, ad.Neighborhood, ad.PostalCode, ad.RegisterDate, c.Id, c.CityName from Address ad join City c on ad.IdCity = c.Id where ad.Id = @Id";
        public readonly static string DELETE = "delete from Address where Id = @Id";
        public readonly static string UPDATE = "update Address set Street = @Street, Number = @Number , Neighborhood = @Neighborhood, PostalCode = @PostalCode, IdCity = @IdCity where Id = @Id";


        public int Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string PostalCode { get; set; }
        public DateTime RegisterDate { get; set; }
        public City City { get; set; }
    }
}