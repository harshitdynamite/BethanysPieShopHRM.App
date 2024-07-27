using BethanysPieShopHRM.Shared.Domain;
using System.Net.Http;
using System.Text.Json;

namespace BethanysPieShopHRM.App.Services
{
    public class CountryDataService : ICountryDataService
    {
        private readonly HttpClient _httpClient;

        public CountryDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }
        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            var list = await JsonSerializer.DeserializeAsync<IEnumerable<Country>>
                   (await _httpClient.GetStreamAsync($"api/country"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return list;

        }

        public async Task<Country> getCountrybyId(int countryId)
        {
            return await JsonSerializer.DeserializeAsync<Country>(await _httpClient.GetStreamAsync($"api/country/{countryId}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
