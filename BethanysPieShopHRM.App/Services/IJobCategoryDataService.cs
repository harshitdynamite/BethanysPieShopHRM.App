using BethanysPieShopHRM.Shared.Domain;

namespace BethanysPieShopHRM.App.Services
{
    public interface IJobCategoryDataService
    {
        public Task<IEnumerable<JobCategory>> GetAllJobCategories();
        public Task<JobCategory> GetJobCategoryById(int id);
    }
}
