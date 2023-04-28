using AndreTurismoApp.Models;
using Newtonsoft.Json;

namespace AndreTurismoApp.Services
{
    public class CityService
    {
        static readonly HttpClient cityClient = new HttpClient();
        public async Task<List<City>> Get()
        {
            try
            {
                HttpResponseMessage response = await CityService.cityClient.GetAsync("https://localhost:7159/api/Cities");
                response.EnsureSuccessStatusCode();
                string city = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<City>>(city);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
    }
}
