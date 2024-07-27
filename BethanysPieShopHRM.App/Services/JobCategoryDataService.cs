using BethanysPieShopHRM.Shared.Domain;
using System.Text.Json;

namespace BethanysPieShopHRM.App.Services
{
    public class JobCategoryDataService : IJobCategoryDataService
    {
        private readonly HttpClient _httpClient;

        public JobCategoryDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<JobCategory>> GetAllJobCategories()
        {
            var list = await JsonSerializer.DeserializeAsync<IEnumerable<JobCategory>>
                   (await _httpClient.GetStreamAsync($"api/jobcategory"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return list;
        }

        public async Task<JobCategory> GetJobCategoryById(int id)
        {
            return await JsonSerializer.DeserializeAsync<JobCategory>(await _httpClient.GetStreamAsync($"api/jobcategory/{id}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
